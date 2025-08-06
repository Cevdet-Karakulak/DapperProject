
using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.SalesDto;
using NuGet.Protocol.Plugins;

namespace DapperProject.Services
{
    public class SelesService : ISalesService
    {
        private readonly DapperContext _context;

        public SelesService(DapperContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalSalesAmountAsync()
        {
            using var connection = _context.CreateConnection();
            string query = "SELECT ISNULL(SUM(TOTALPRICE), 0) FROM [SALES10M].[dbo].[SALES] WITH (NOLOCK)";
            return await connection.ExecuteScalarAsync<decimal>(query);
        }
        public async Task<int> GetTotalSalesCountAsync()
        {
            using var connection = _context.CreateConnection();
            string query = "SELECT COUNT(*) FROM [SALES10M].[dbo].[SALES] WITH (NOLOCK)";
            return await connection.ExecuteScalarAsync<int>(query);
        }
        public async Task<string> GetTopSellingProductAsync()
        {
            using var connection = _context.CreateConnection();
            string query = @"
            SELECT TOP 1 ITEMNAME
            FROM [SALES10M].[dbo].[SALES] WITH (NOLOCK)
            GROUP BY ITEMNAME
            ORDER BY SUM(AMOUNT) DESC";
            return await connection.ExecuteScalarAsync<string>(query);
        }

        public async Task<string> GetTopCityAsync()
        {
            using var connection = _context.CreateConnection();
            string query = @"
            SELECT TOP 1 CITY
            FROM [SALES10M].[dbo].[SALES] WITH (NOLOCK)
            GROUP BY CITY
            ORDER BY SUM(TOTALPRICE) DESC";
            return await connection.ExecuteScalarAsync<string>(query);
        }

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync()
        {
            using var connection = _context.CreateConnection();

            var query = @"
            WITH RankedOrders AS (
                SELECT
                    USERID,
                    NAMESURNAME,
                    CITY,
                    TOTALPRICE,
                    AMOUNT,
                    ITEMNAME,
                    DATE_,
                    ROW_NUMBER() OVER (PARTITION BY USERID ORDER BY DATE_ DESC, ORDERID DESC) AS rn
                FROM SALES10M.dbo.SALES
            )
            SELECT TOP 6
                USERID AS UserId,
                NAMESURNAME AS NameSurname,
                CITY,
                SUM(TOTALPRICE) AS TotalPurchaseAmount,
                SUM(AMOUNT) AS PurchaseCount,
                MAX(CASE WHEN rn = 1 THEN ITEMNAME END) AS TopProduct
            FROM RankedOrders
            GROUP BY USERID, NAMESURNAME, CITY
            ORDER BY TotalPurchaseAmount DESC";

            var result = await connection.QueryAsync<TopCustomerDto>(
         new CommandDefinition(query, commandTimeout: 120)
        );


            return result.ToList();
        }


        public async Task<List<RegionSalesDto>> GetSalesByRegionAsync()
        {
            using var connection = _context.CreateConnection();
            var query = @"
            SELECT REGION AS RegionName, SUM(TOTALPRICE) AS TotalSales
            FROM SALES10M.dbo.SALES
            GROUP BY REGION
            ORDER BY TotalSales DESC";

            var result = await connection.QueryAsync<RegionSalesDto>(query);
            return result.ToList();
        }


        public async Task<object> GetSalesByAgeGroupAsync()
        {
            string query = @"
                       SELECT 
                CASE 
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 18 AND 20 THEN '18-20'
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 21 AND 30 THEN '21-30'
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 31 AND 50 THEN '31-50'
                    ELSE '50+' 
                END AS AgeGroup,
                SUM(TOTALPRICE) AS TotalRevenue
            FROM SALES
            GROUP BY 
                CASE 
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 18 AND 20 THEN '18-20'
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 21 AND 30 THEN '21-30'
                    WHEN DATEDIFF(YEAR, USERBIRTHDATE, GETDATE()) BETWEEN 31 AND 50 THEN '31-50'
                    ELSE '50+' 
                END
            ORDER BY TotalRevenue DESC";

            var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<dynamic>(query);
            return result.ToList();
        }

        public async Task<List<BrandSalesDto>> GetBrandSalesAsync()
        {
            using var connection = _context.CreateConnection();
            var query = @"
            SELECT 
                BRAND AS BrandName,
                SUM(TOTALPRICE) AS TotalSales
            FROM SALES10M.dbo.SALES
            GROUP BY BRAND
            ORDER BY TotalSales DESC";

            var result = await connection.QueryAsync<BrandSalesDto>(query);
            return result.ToList();
        }
        public async Task<List<SalesDto>> GetSalesWithFilterAsync(string productName = "", string category = "", string customerName = "", string region = "", string city = "")
        {
            var whereConditions = new List<string>();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(productName))
            {
                whereConditions.Add("ITEMNAME LIKE @ProductName");
                parameters.Add("@ProductName", $"%{productName}%");
            }

            if (!string.IsNullOrEmpty(category))
            {
                whereConditions.Add("CATEGORY1 = @Category");
                parameters.Add("@Category", category);
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                whereConditions.Add("NAMESURNAME LIKE @CustomerName");
                parameters.Add("@CustomerName", $"%{customerName}%");
            }

            if (!string.IsNullOrEmpty(region))
            {
                whereConditions.Add("REGION = @Region");
                parameters.Add("@Region", region);
            }

            if (!string.IsNullOrEmpty(city))
            {
                whereConditions.Add("CITY = @City");
                parameters.Add("@City", city);
            }

            var whereClause = whereConditions.Count > 0 ? "WHERE " + string.Join(" AND ", whereConditions) : "";
            string query = $"SELECT TOP 1000 * FROM SALES {whereClause} ORDER BY DATE_ DESC";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<SalesDto>(query, parameters);
            return values.ToList();
        }

        public async Task<object> GetSalesByCategoryAsync()
        {
            string query = @"
            SELECT CATEGORY1, SUM(TOTALPRICE) AS TotalRevenue
            FROM SALES
            GROUP BY CATEGORY1
            ORDER BY TotalRevenue DESC";
            var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<dynamic>(query);
            return result.ToList();
        }


        public async Task<object> GetTopSellingProductsAsync()
        {
            string query = @"
            SELECT TOP 10 ITEMNAME, SUM(AMOUNT) AS TotalAmount
            FROM SALES
            GROUP BY ITEMNAME
            ORDER BY TotalAmount DESC";

            var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<dynamic>(query);
            return result.ToList();
        }
        public async Task<(List<SalesListDto> Data, int TotalCount)> GetPagedSalesAsync(int page, int pageSize, string search, string city, string brand)
        {
            using var connection = _context.CreateConnection();

            var filters = new List<string>();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(search))
            {
                filters.Add("(ITEMNAME LIKE @Search OR NAMESURNAME LIKE @Search)");
                parameters.Add("@Search", $"%{search}%");
            }

            if (!string.IsNullOrEmpty(city))
            {
                filters.Add("CITY = @City");
                parameters.Add("@City", city);
            }

            if (!string.IsNullOrEmpty(brand))
            {
                filters.Add("BRAND = @Brand");
                parameters.Add("@Brand", brand);
            }

            string whereClause = filters.Count > 0 ? "WHERE " + string.Join(" AND ", filters) : "";

            string countQuery = $"SELECT COUNT(1) FROM SALES {whereClause}";
            int totalCount = await connection.ExecuteScalarAsync<int>(countQuery, parameters, commandTimeout: 120);

            string query = $@"
            SELECT ID, ITEMNAME, BRAND, CITY, TOTALPRICE, DATE_ 
            FROM SALES
            {whereClause}
            ORDER BY DATE_ DESC
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            parameters.Add("@Offset", (page - 1) * pageSize);
            parameters.Add("@PageSize", pageSize);

            var data = await connection.QueryAsync<SalesListDto>(query, parameters, commandTimeout: 120);

            return (data.ToList(), totalCount);
        }


    }
}
using DapperProject.Dtos.SalesDto;

namespace DapperProject.Services
{
    public interface ISalesService
    {
        Task<object> GetTopSellingProductsAsync();
        Task<object> GetSalesByAgeGroupAsync();
        Task<object> GetSalesByCategoryAsync();
        Task<decimal> GetTotalSalesAmountAsync();
        Task<int> GetTotalSalesCountAsync();
        Task<string> GetTopSellingProductAsync();
        Task<string> GetTopCityAsync();
        Task<List<TopCustomerDto>> GetTopCustomersAsync();
        Task<List<BrandSalesDto>> GetBrandSalesAsync();
        Task<List<RegionSalesDto>> GetSalesByRegionAsync();
        Task<(List<SalesListDto> Data, int TotalCount)> GetPagedSalesAsync(int page, int pageSize, string search, string city, string brand);

    }
}
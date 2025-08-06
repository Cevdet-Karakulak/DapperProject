namespace DapperProject.Dtos.SalesDto
{
    public class SalesListDto
    {
        public int ID { get; set; }
        public string ITEMNAME { get; set; }
        public string BRAND { get; set; }
        public string CITY { get; set; }
        public decimal UNITPRICE { get; set; }
        public int AMOUNT { get; set; }
        public decimal TOTALPRICE { get; set; }
        public DateTime DATE_ { get; set; }
    }
}
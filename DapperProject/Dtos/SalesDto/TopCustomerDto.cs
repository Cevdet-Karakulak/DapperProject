namespace DapperProject.Dtos.SalesDto
{
    public class TopCustomerDto
    {
        public string NameSurname { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public int PurchaseCount { get; set; }
        public string City { get; set; }
    }
}
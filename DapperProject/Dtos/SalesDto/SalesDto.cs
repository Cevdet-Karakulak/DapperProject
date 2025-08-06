namespace DapperProject.Dtos.SalesDto
{
    public class SalesDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string Brand { get; set; }
        public string UserGender { get; set; }
        public DateTime UserBirthDate { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string AddressText { get; set; }
        public int AddressId { get; set; }
    }
}
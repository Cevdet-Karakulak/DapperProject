using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ISalesService _salesService;

        public DashboardController(ISalesService salesService)
        {
            _salesService = salesService;
        }


        public async Task<IActionResult> Index()
        {
            var topSellingProducts = await _salesService.GetTopSellingProductsAsync();
            var salesByAgeGroup = await _salesService.GetSalesByAgeGroupAsync();
            var salesByCategory = await _salesService.GetSalesByCategoryAsync();
            var totalSalesAmount = await _salesService.GetTotalSalesAmountAsync();
            var totalSalesCount = await _salesService.GetTotalSalesCountAsync();
            var topProduct = await _salesService.GetTopSellingProductAsync();
            var topCity = await _salesService.GetTopCityAsync();
            var topCustomers = await _salesService.GetTopCustomersAsync();
            var salesByRegion=await _salesService.GetSalesByRegionAsync();



            ViewBag.TopSellingProducts = topSellingProducts;
            ViewBag.SalesByAgeGroup = salesByAgeGroup;
            ViewBag.SalesByCategory = salesByCategory;
            ViewBag.TotalSalesAmount = totalSalesAmount;
            ViewBag.TotalSalesCount = totalSalesCount;
            ViewBag.TopProduct = topProduct;
            ViewBag.TopCity = topCity;
            ViewBag.SalesByRegion = salesByRegion;

            return View(topCustomers);
        }      
        
    }
}
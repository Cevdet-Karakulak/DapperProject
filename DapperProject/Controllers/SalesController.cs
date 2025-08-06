using DapperProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DapperProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;
        private const int PageSize = 100;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IActionResult> Index(int page = 1, string search = "", string city = "", string brand = "")
        {
            var (data, totalCount) = await _salesService.GetPagedSalesAsync(page, PageSize, search, city, brand);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            ViewBag.Search = search;
            ViewBag.City = city;
            ViewBag.Brand = brand;

            return View(data);
        }
    }
}

using System.Diagnostics; // To use Controller, IActionResult.
using Microsoft.AspNetCore.Mvc; // To use ErrorViewModel.
using Northwind.Mvc.Models; // To use Activity.
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels; // To use Include method.

namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext _db;

    public HomeController(
        ILogger<HomeController> logger,
        NorthwindContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        // Logger types
        // _logger.LogError("This is a serious error (not really!)");
        // _logger.LogWarning("This is your first warning!");
        // _logger.LogWarning("Second warning!");
        // _logger.LogInformation("I am in the Index method of the HomeController");

        HomeIndexViewModel model = new
        (
            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: _db.Categories.ToList(),
            Products: _db.Products.ToList()
        );

        return View(model); // Pass the model to the view.
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ProductDetail(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
        }

        Product? model = _db.Products
        .Include(p => p.Category)
        .SingleOrDefault(p => p.ProductId == id);

        if (model is null)
        {
            return NotFound($"ProductId {id} not found.");
        }

        return View(model);
    }
}

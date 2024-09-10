using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace Northwind.Web.Pages
{
    public class SuppliersModel : PageModel
    {
        private NorthwindContext _db;
        public IEnumerable<Supplier>? Suppliers { get; set; }

        public SuppliersModel(NorthwindContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Suppliers";

            Suppliers = _db.Suppliers
            .OrderBy(s => s.Country)
            .ThenBy(s => s.CompanyName);
        }

        [BindProperty] // To easily connect HTML elements on the web page to properties in the Supplier Class
        public Supplier? Supplier { get; set; }
        public IActionResult OnPost() // The method that responds to HTTP Post requests.
        {
            if (Supplier is not null && ModelState.IsValid)
            {
                _db.Suppliers.Add(Supplier);
                _db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
            {
                return Page();
            }
        }
    }
}

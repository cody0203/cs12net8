using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace Northwind.Web.Pages;

public class CustomersModel : PageModel
{
    public ILookup<string?, Customer>? CustomersByCountry;

    private NorthwindContext _db;

    public CustomersModel(NorthwindContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        CustomersByCountry = _db.Customers.ToLookup(c => c.Country);
    }
}
﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace PacktFeatures.Pages;

public class EmployeeListPageModel : PageModel
{
    private NorthwindContext _db;
    
    public EmployeeListPageModel(NorthwindContext db)
    {
        _db = db;
    }

    public Employee[] Employees { get; set; } = null!;

    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Employees";

        Employees = _db.Employees
        .OrderBy(e => e.LastName)
        .ThenBy(e => e.FirstName)
        .ToArray();
    }
}

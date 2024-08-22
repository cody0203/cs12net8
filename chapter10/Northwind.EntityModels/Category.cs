using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

public class Category
{
    // These properties map to columns in the database.
    public int CategoryId { get; set; } // the primary key.
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    // Defines a navigation property for relates rows.
    // To enable developers to add products to a Category, we must
    // initialize the navigation property to an empty collection.
    // This is also avoids an exception if we get a member like Count.
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
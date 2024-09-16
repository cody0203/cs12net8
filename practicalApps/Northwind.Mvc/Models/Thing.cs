using System.ComponentModel.DataAnnotations; // To use [Range], [Required], [EmaiLAddress]

namespace Northwind.Mvc.Models;

public record Thing(
    [Range(0, 10)] int? Id,
    [Required] string? Color,
    [EmailAddress] string? Email
);
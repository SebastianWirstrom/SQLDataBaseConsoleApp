using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
}

using Infrastructure.DTOs;
using Infrastructure.Services;
using System.Diagnostics;

namespace Presentation.ConsoleApp;

public class MenuService(ProductService productService)
{
    private readonly ProductService _productService = productService;

    public void CreateProductMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Create Product");

            var product = new ProductDTO();

            Console.Write("Product Title: ");
            product.Title = Console.ReadLine()!;

            Console.Write("Product Price: ");
            product.Price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Product Description: ");
            product.Description = Console.ReadLine()!;

            Console.Write("Product Category: ");
            product.CategoryName = Console.ReadLine()!;

            var result = _productService.CreateProduct(product);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine($"Product (Article number: {result.Id}) was created. \n" +
                    $"Title: {result.Title} \n" +
                    $"Description: {result.Description}\n" +
                    $"Price: {result.Price} \n" +
                    $"Category: {result.Category}");
                Console.WriteLine();
                Console.Write("Press any key to proceed");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        
    }
}


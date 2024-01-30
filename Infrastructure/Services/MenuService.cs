using Infrastructure.DTOs;
using Infrastructure.Services;
using System.Diagnostics;

namespace Presentation.ConsoleApp;

public class MenuService(ProductService productService)
{
    private readonly ProductService _productService = productService;


    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("           Main Menu            ");
        Console.WriteLine("________________________________");
        Console.WriteLine("");
        Console.WriteLine("1. Create new product");
        Console.WriteLine("2. Create new customer");
        Console.WriteLine("3. Find product");
        Console.WriteLine("4. Show all products");
        Console.WriteLine("5. Find customer");
        Console.WriteLine("6. Show all customers");
        Console.WriteLine("");
        Console.WriteLine("0. Exit application");
        Console.WriteLine("");
        Console.Write("Please select an option to proceed: ");
        
        var option = Console.ReadLine()!;

        switch (option)
        {
            case "1":
                CreateProductMenu(); 
                break;

            case "2":
                CreateCustomerMenu();
                break;

            case "3":
                GetProductMenu();
                break;

            case "4":
                GetProductsMenu();
                break;

            case "5":
                GetCustomerMenu();
                break;

            case "6":
                GetCustomersMenu();
                break;

            case: "0":
                    ShowExitApplicationMenu();
                break;

            default:
                Console.Clear();
                Console.WriteLine("Something went wrong. Press any key to try again!");
                break;
            
        }

    }
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
    public void CreateCustomerMenu()
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


using Infrastructure.DTOs;
using Infrastructure.Services;
using System.Diagnostics;

namespace Presentation.ConsoleApp;

public class MenuService(ProductService productService, CustomerService customerService)
{
    private readonly ProductService _productService = productService;
    private readonly CustomerService _customerService = customerService;

    public void MainMenu()
    {
        try
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("      Main Menu       ");
                Console.WriteLine("______________________\n");
                Console.WriteLine("1. Create new product");
                Console.WriteLine("2. Create new customer");
                Console.WriteLine("3. Find product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Find customer");
                Console.WriteLine("6. Show all customers");
                Console.WriteLine("7. Update product information");
                Console.WriteLine("8. Update customer information");
                Console.WriteLine("");
                Console.WriteLine("DC. Delete a product");
                Console.WriteLine("DP. Delete a customer");
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

                    case "7":
                        UpdateProductMenu();
                        break;

                    case "8":
                        UpdateCustomerMenu();
                        break;

                    case "DP":
                        DeleteProductMenu();
                        break;

                    case "DC":
                        DeleteCustomerMenu();
                        break;

                    case "0":
                        ShowExitApplicationMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Something went wrong. Press any key to try again!");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    public void CreateCustomerMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Add new Customer");

            var customer = new CustomerDTO();

            Console.Write("First name: ");
            customer.FirstName = Console.ReadLine()!;

            Console.Write("Last name: ");
            customer.LastName = Console.ReadLine()!;

            Console.Write("E-mail: ");
            customer.Email = Console.ReadLine()!;

            Console.Write("Customer company role: ");
            customer.Role.RoleName = Console.ReadLine()!;

            Console.Write("Street address: ");
            customer.Address.StreetName = Console.ReadLine()!;

            Console.Write("Zip code: ");
            customer.Address.PostalCode = Console.ReadLine()!;

            Console.Write("City: ");
            customer.Address.City = Console.ReadLine()!;

            var result = _customerService.CreateCustomer(customer);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine($"Customer {result.FirstName} {result.LastName} (Customer number: {result.Id}) was created. \n" +
                    $"First name: {result.FirstName} \n" +
                    $"Last name: {result.LastName}\n" +
                    $"E-mail: {result.Email} \n" +
                    $"Role: {result.Role.RoleName} \n" +
                    $"Street address: {result.Address.StreetName} \n" +
                    $"Zip code: {result.Address.PostalCode} \n" +
                    $"Address: {result.Address.StreetName} \n" +
                    $"City: {result.Address.City}");

                Console.WriteLine("");
                Console.Write("Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
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
                    $"Category: {result.Category.CategoryName}");

                Console.WriteLine("");
                Console.Write("Press any key to return to the main menu");
                Console.ReadKey();
                
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }

    }
    public void GetProductMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("     FIND PRODUCT     ");
            Console.WriteLine("______________________\n");

            Console.Write("Please enter the product ID: ");
            var productId = int.Parse(Console.ReadLine()!);

            var product = _productService.GetProductById(productId);

            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"Product information: \n\n" +
                    $"Article number/ID: {product.Id}\n" +
                    $"Title: {product.Title}\n" +
                    $"Description: {product.Description}\n" +
                    $"Price: {product.Price} SEK\n" +
                    $"Category: {product.Category.CategoryName}\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No product with that ID was found.\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
    }
    public void GetProductsMenu()
    {
        try
        {
            Console.Clear();
            var products = _productService.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Title}, {product.Price} SEK");
            }
            Console.WriteLine("");
            Console.Write("Press any key to return to the main menu");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
    }
    public void GetCustomerMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("     FIND CUSTOMER     ");
            Console.WriteLine("______________________\n");

            Console.Write("Please enter the customer E-mail: ");
            var customerEmail = Console.ReadLine()!;

            var customer = _customerService.GetCustomerByEmail(customerEmail);

            if (customer != null)
            {
                Console.Clear();
                Console.WriteLine($"Customer information: \n\n" +
                    $"Customer number/ID: {customer.Id}\n" +
                    $"First Name: {customer.FirstName}\n" +
                    $"Last Name : {customer.LastName}\n" +
                    $"E-mail: <{customer.Email}>\n" +
                    $"Company title: {customer.Role.RoleName}\n" +
                    $"Street name: {customer.Address.StreetName}\n" +
                    $"Zip code: {customer.Address.PostalCode}\n" +
                    $"City: {customer.Address.City}\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No customer with that E-mail was found.\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
    }
    public void GetCustomersMenu()
    {
        try
        {
            Console.Clear();
            var customers = _customerService.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}, <{customer.Email}> Customer number: [{customer.Id}]");
            }
            Console.WriteLine("");
            Console.Write("Press any key to return to the main menu");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
    }
    public void UpdateProductMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Enter product id: ");

            var productId = int.Parse(Console.ReadLine()!);

            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                Console.WriteLine($"{product.Title}, {product.Price} SEK");
                Console.WriteLine("");

                Console.WriteLine("Please enter the new product title: ");
                product.Title = Console.ReadLine()!;

                Console.WriteLine("Please enter the new product title: ");
                product.Price = int.Parse(Console.ReadLine()!);

                var newProduct = _productService.UpdateProduct(product);

                Console.WriteLine("Product was updated!");
                Console.WriteLine("");
                Console.Write("Press any key to return to the main menu");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No product with that ID was found.\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        } 
    }
    public void UpdateCustomerMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Enter Customer E-mail: ");

            var customerEmail = Console.ReadLine()!;

            var customer = _customerService.GetCustomerByEmail(customerEmail);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}> [Customer number: {customer.Id}]");
                Console.WriteLine("");

                Console.WriteLine("Enter a new customer first name");
                customer.FirstName = Console.ReadLine()!;

                Console.WriteLine("Enter a new customer last name");
                customer.LastName = Console.ReadLine()!;

                Console.WriteLine("Enter a new customer E-mail");
                customer.Email = Console.ReadLine()!;

                var newCustomer = _customerService.UpdateCustomer(customer);

                Console.WriteLine("Customer was updated!\n");
                Console.WriteLine("");
                Console.Write("Press any key to return to the main menu");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No customer found with that E-mail\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        
    }
    public void DeleteProductMenu()
    {
        try
        {
            Console.Clear();
            Console.Write("Enter product id: ");

            var productId = int.Parse(Console.ReadLine()!);

            var product = _productService.GetProductById(productId);

            if (product != null)
            {
                Console.WriteLine($"{product.Title}, {product.Price} SEK");
                Console.WriteLine("");

                Console.WriteLine("Please confirm you wish to delete this product (y/n)");
                var result = Console.ReadLine()!;
                if (result == "y")
                {
                    _productService.DeleteProduct(product.Id);
                    Console.WriteLine("Product was deleted!\n");
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                }
                if (result == "n")
                {
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No product with that ID was found.\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        
    }
    public void DeleteCustomerMenu()
    {
        try
        {
            Console.Clear();
            Console.Write("Enter customer E-mail: ");

            var customerEmail = (Console.ReadLine()!);

            var customer = _customerService.GetCustomerByEmail(customerEmail);

            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName}, {customer.LastName} <{customer.Email}>");
                Console.WriteLine("");

                Console.WriteLine("Please confirm you wish to delete this customer (y/n)");
                var result = Console.ReadLine()!;
                if (result.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    _customerService.DeleteCustomer(customer.Id);
                    Console.WriteLine("Customer was deleted!\n");
                    Console.Write("Press any key to return to the main menu: ");
                    Console.ReadKey();
                }
                if (result.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Write("Press any key to return to the main menu: ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No customer with that E-mail was found.\n");
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        
    }
    public void ShowExitApplicationMenu()
    {
        try
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit this application? (y/n) ");

            var option = Console.ReadLine()!;

            if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}


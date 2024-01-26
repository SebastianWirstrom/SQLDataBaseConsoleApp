using Infrastructure.Interfaces;
namespace Infrastructure.Services;

public interface IMenuService
{
    void ShowMainMenu();
}

public class MenuService : IMenuService
{
    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("_________________________");
            Console.WriteLine("1. Create new customer");
            Console.WriteLine("2. Find customer my e-mail");
            Console.WriteLine("3. Show all existing customers");
            Console.WriteLine("4. Update existing customer");
            Console.WriteLine("5. Delete existing customer");
            Console.WriteLine("");
            Console.WriteLine("0. Exit application");
            Console.WriteLine("");
            Console.Write("Select an option to proceed: ");

            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":

                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "0":
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option selected. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public void ShowCreateNewCustomerMenu()
    {
        throw new NotImplementedException();
    }

    public void ShowDeleteCustomerMenu()
    {
        throw new NotImplementedException();
    }

    public void ShowGetCustomerMenu()
    {
        throw new NotImplementedException();
    }

    public void ShowGetCustomersMenu()
    {
        throw new NotImplementedException();
    }

    



}

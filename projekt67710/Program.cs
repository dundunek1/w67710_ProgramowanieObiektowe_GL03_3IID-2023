
using ConsoleApp1.Models;
using ConsoleApp1.Utils;

//Jakub Pawlik w67710
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var expenseList = new List<Expense>();

            while (true)
            {
                Console.WriteLine("Expense Tracking App");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Display Expenses");
                Console.WriteLine("3. Delete Expense");
                Console.WriteLine("4. Update Expense");
                Console.WriteLine("5. Raport");
                Console.WriteLine("0. exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HelperMethods.AddExpense(expenseList);
                        break;

                    case "2":
                        HelperMethods.DisplayExpenses(expenseList);
                        break;

                    case "3":
                        HelperMethods.DeleteExpense(expenseList);
                        break;

                    case "4":
                        HelperMethods.UpdateExpense(expenseList);
                        break;
                    case "5":
                        HelperMethods.GenerateExpenseReport(expenseList);
                        break;

                    case "0":
                        Console.WriteLine("Exiting the application.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); 
            }
        }


       
    }
}


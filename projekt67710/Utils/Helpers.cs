using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Utils
{
    public static class HelperMethods
    {

        public static void AddExpense(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("enter description: ");
            string description = Console.ReadLine();

            Console.WriteLine("enter amount: ");
            double amount;
            if (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("invalid amount. expense not added.");
                return;
            }

            Console.WriteLine("choose category or create a new one (input 0): ");
            var categories = Category.PredefinedCategories();

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }

            Console.WriteLine("enter category number: ");
            int categoryId;
            if (!int.TryParse(Console.ReadLine(), out categoryId) || !Category.IsValidCategoryId(categoryId))
            {
                Console.WriteLine("invalid category ID. expense not added.");
                return;
            }
            if (categoryId == 0)
            {
               
            }
            Category selectedCategory = Category.GetCategoryById(categoryId);
            Expense newExpense = new Expense(expenseList.Count + 1, description, amount, selectedCategory);
            expenseList.Add(newExpense);

            Console.WriteLine("expense added successfully.");
            int i = 1;
            

            foreach (Expense expense in expenseList)
            {
                Console.WriteLine($"{i} {expense.DisplayText}");
                i++;
            }
        }

        public static void DisplayExpenses(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("expenses:");
            int i = 1;
            foreach (Expense expense in expenseList)
            {
                Console.WriteLine($"{i} {expense.DisplayText}");
                i++;
            }
        }

        public static void DeleteExpense(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("enter the ID of the expense to delete: ");
            Console.WriteLine("expenses:");
            int i = 1;
            foreach (Expense expense in expenseList)
            {
                Console.WriteLine($"{i} {expense.DisplayText}");
                i++;
            }
            int expenseId;
            if (!int.TryParse(Console.ReadLine(), out expenseId))
            {
                Console.WriteLine("invalid expense ID.");
                return;
            }
            
            Expense expenseToRemove = expenseList.Find(expense => expense.Id == expenseId);
            if (expenseToRemove != null)
            {
                expenseList.Remove(expenseToRemove);
                Console.WriteLine("expense deleted successfully.");
            }
            else
            {
                Console.WriteLine("expense not found.");
            }
        }

        public static void UpdateExpense(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("enter the ID of the expense to update: ");
            Console.WriteLine("expenses:");
            int i = 1;
            foreach (Expense expense in expenseList)
            {
                Console.WriteLine($"{i} {expense.DisplayText}");
                i++;
            }
            int expenseId;
            if (!int.TryParse(Console.ReadLine(), out expenseId))
            {
                Console.WriteLine("invalid expense ID.");
                return;
            }

            Expense expenseToUpdate = expenseList.Find(expense => expense.Id == expenseId);
            if (expenseToUpdate != null)
            {
                Console.WriteLine("enter new description (press Enter to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                    expenseToUpdate.Description = newDescription;
                }

                Console.WriteLine("enter new amount (press Enter to keep current): ");
                string newAmountString = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAmountString) && double.TryParse(newAmountString, out double newAmount))
                {
                    expenseToUpdate.Amount = newAmount;
                }

                Console.WriteLine("expense updated successfully.");
            }
            else
            {
                Console.WriteLine("expense not found.");
            }
        }

        public static void GenerateExpenseReport(List<Expense> expenseList)
        {
            Console.Clear();
            Console.WriteLine("detailed expense report:");
            Console.WriteLine("----------------------------------------");

            if (expenseList.Any())
            {
                

                var groupedExpenses = expenseList.GroupBy(expense => expense.Category);

                foreach (var categoryGroup in groupedExpenses)
                {
                    Console.WriteLine($"category: {categoryGroup.Key.Name}");
                    Console.WriteLine("----------------------------------------");

                    double categoryTotalAmount = 0;
                    int categoryExpenseCount = 0;

                    foreach (Expense expense in categoryGroup)
                    {
                        Console.WriteLine($"description: {expense.Description}");
                        Console.WriteLine($"amount: {expense.Amount:C}");
                        Console.WriteLine("----------------------------------------");

                        categoryTotalAmount += expense.Amount;
                        categoryExpenseCount++;
                    }

                    Console.WriteLine($"total expenses for {categoryGroup.Key.Name}: {categoryTotalAmount:C}");
                    Console.WriteLine($"number of expenses for {categoryGroup.Key.Name}: {categoryExpenseCount}");
                    Console.WriteLine("----------------------------------------");
                }

                double totalAmount = expenseList.Sum(expense => expense.Amount);
                int totalExpenseCount = expenseList.Count;

                Console.WriteLine($"total expenses for all categories: {totalAmount:C}");
                Console.WriteLine($"number of all expenses: {totalExpenseCount}");
            }
            else
            {
                Console.WriteLine("no expenses to report.");
            }
        }
    }
}

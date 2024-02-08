using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public Category Category { get; set; }

        
        public string DisplayText => $"{Description} - {Amount:C} ({Category.Name})";

        public Expense(int id, string description, double amount, Category category)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Category = category;
        }
    }
}


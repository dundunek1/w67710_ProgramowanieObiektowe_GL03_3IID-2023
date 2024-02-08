using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public static readonly Category Food = new Category(1, "Food");
        public static readonly Category Transportation = new Category(2, "Transportation");
        public static readonly Category Utilities = new Category(3, "Utilities");
        public static readonly Category Other = new Category(4, "Other");

        private Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        

       

       
        public static List<Category> PredefinedCategories()
        {
            return new List<Category> { Food, Transportation, Utilities, Other };
        }

        
        public static bool IsValidCategoryId(int categoryId)
        {
            return PredefinedCategories().Any(category => category.Id == categoryId);
        }

        
        public static Category GetCategoryById(int categoryId)
        {
            
            return PredefinedCategories().FirstOrDefault(category => category.Id == categoryId);
        }

    }
}

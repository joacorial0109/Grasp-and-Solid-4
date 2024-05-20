using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static List<Product> productCatalog = new List<Product>();
        private static List<Equipment> equipmentCatalog = new List<Equipment>();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");

            // Utilizamos el método CreateStep de Recipe para crear los pasos
            Step step1 = recipe.CreateStep(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120);
            Step step2 = recipe.CreateStep(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60);
            
            recipe.AddStep(step1);
            recipe.AddStep(step2);

            IPrinter printer;
            printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);
            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product GetProduct(string description)
        {
            foreach (var product in productCatalog)
            {
                if (product.Description == description)
                {
                    return product;
                }
            }
            return null;
        }

        private static Equipment GetEquipment(string description)
        {
            foreach (var equipment in equipmentCatalog)
            {
                if (equipment.Description == description)
                {
                    return equipment;
                }
            }
            return null;
        }
    }
}

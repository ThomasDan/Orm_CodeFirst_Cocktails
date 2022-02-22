using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm_CodeFirst_Cocktails.classes;

namespace Orm_CodeFirst_Cocktails.view
{
    public class MainMenu
    {
        public char GetInput()
        {
            return Console.ReadKey().KeyChar;
        }
        public void TypeOptions()
        {
            Console.WriteLine("Welcome to the Cocktail Database!\n-----------------------------\n\n" +
                "Press one of the following keys to continue:\n" +
                "1. Cocktails CRUD | Any other key to Quit");
        }

        /// <summary>
        /// Should construct the string in the logic layer, but no time.
        /// </summary>
        /// <param name="cocktails"></param>
        public void PastaCocktails(List<Cocktail> cocktails)
        {
            Console.Clear();
            Console.WriteLine("\n\n### COCKTAILS ###\n\n " +
                string.Join("\n ", 
                    cocktails.Select(c => c.Name + "\n  " + 
                        string.Join("\n  ", 
                            c.Cocktail_Ingredients.Select(ig => ig.Ingredient.Name + " - " + ig.Quantity + " " + ig.Ingredient.UnitType.Type)
                            ))));
        }
    }
}

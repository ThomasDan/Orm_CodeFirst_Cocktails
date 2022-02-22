using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm_CodeFirst_Cocktails.classes;
using Orm_CodeFirst_Cocktails.DAL;
using Orm_CodeFirst_Cocktails.view;

namespace Orm_CodeFirst_Cocktails.logic
{
    public class Repeater
    {
        private static CocktailDBContext cocktailDB = new CocktailDBContext();
        private static MainMenu menu = new MainMenu();
        public static void Run()
        {
            
            cocktailDB.SeedDatabase();

            bool done = false;
            char input;
            while (!done)
            {
                menu.TypeOptions();
                input = menu.GetInput();
                done = Choice(input);
            }
        }

        static bool Choice(char input)
        {
            switch (input)
            {
                case '1':
                    // Drinks CRUD
                    menu.PastaCocktails(cocktailDB.FullCocktails());
                    break;



                default:
                    // QUit
                    return true;
            }
            return false;
        }

        
    }
}

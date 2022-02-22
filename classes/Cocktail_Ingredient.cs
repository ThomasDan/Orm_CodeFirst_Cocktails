using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm_CodeFirst_Cocktails.classes
{
    public class Cocktail_Ingredient
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int Cocktail_Id { get; set; }
        public Cocktail Cocktail { get; set; }
        public int Ingredient_Id { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}

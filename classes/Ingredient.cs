using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm_CodeFirst_Cocktails.classes.interfaces;

namespace Orm_CodeFirst_Cocktails.classes
{
    public abstract class Ingredient : IUnitTyped
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public UnitType UnitType { get; set; }
        public ICollection<Cocktail_Ingredient> Cocktail_Ingredients { get; set; }
    }
}

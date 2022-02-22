using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm_CodeFirst_Cocktails.classes
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Receptacle_Id { get; set; }
        public Receptacle Receptacle { get; set; }
        public ICollection<Cocktail_Ingredient> Cocktail_Ingredients { get; set; }
    }
}

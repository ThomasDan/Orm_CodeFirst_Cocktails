using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm_CodeFirst_Cocktails.classes
{
    public class Receptacle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MLCapacity { get; set; }

        public ICollection<Cocktail> Cocktails { get; set; }
    }
}

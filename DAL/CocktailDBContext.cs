using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Orm_CodeFirst_Cocktails.classes;

namespace Orm_CodeFirst_Cocktails.DAL
{
    public class CocktailDBContext : DbContext
    {

        public void SeedDatabase()
        {
            SeedReceptacles();

            SeedUnitTypes();

            SeedIngredients();

            SeedCocktails();

            SeedCocktailIngredients();
        }

        private void SeedReceptacles()
        {
            using (var ctx = new CocktailDBContext())
            {
                // Receptacles
                ctx.Receptacles.AddRange(new List<Receptacle>()
                {
                    new Receptacle() { Name = "Tall Glass", MLCapacity = 100 },
                    new Receptacle() { Name = "Medium Glass", MLCapacity = 400 },
                    new Receptacle() { Name = "Small Glass", MLCapacity = 200 },
                    new Receptacle() { Name = "Mug", MLCapacity = 350 }
                });

                ctx.SaveChanges();
            }
        }
        private void SeedUnitTypes()
        {
            using (var ctx = new CocktailDBContext())
            {
                // UnitTypes
                ctx.UnitTypes.AddRange(new List<UnitType>()
                {
                    new UnitType() { Type=""},
                    new UnitType() { Type="ml"},
                    new UnitType() { Type="splashes"},
                    new UnitType() { Type="slices"},
                    new UnitType() { Type="tsp"}
                });

                ctx.SaveChanges();
            }
        }
        private void SeedIngredients()
        {
            using (var ctx = new CocktailDBContext())
            {
                // Ingredients
                ctx.Alcohols.AddRange(new List<Alcohol>()
                {
                    new Alcohol() { Name="Vodka", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("ml")).First(), Percentage=30.3},
                    new Alcohol() { Name="Bourbon", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("ml")).First(), Percentage=50.3},
                    new Alcohol() { Name="Kahluah", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("ml")).First(), Percentage=15.6}
                });
                ctx.Miscs.AddRange(new List<Misc>()
                {
                    new Misc() { Name="Milk", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("ml")).First()},
                    new Misc() { Name="Onion", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("slices")).First()},
                    new Misc() { Name="Ice Cubes", UnitType=ctx.UnitTypes.Where(ut => ut.Type.Equals("")).First()}
                });

                ctx.SaveChanges();
            }
        }
        private void SeedCocktails()
        {
            using (var ctx = new CocktailDBContext())
            {
                // Cocktails
                ctx.Cocktails.AddRange(new List<Cocktail>()
                {
                    new Cocktail() { Name = "Crying Bastard", Receptacle = ctx.Receptacles.Where(ut => ut.Name.Equals("Mug")).First() },
                    new Cocktail() { Name = "White Russian", Receptacle = ctx.Receptacles.Where(ut => ut.Name.Equals("Medium Glass")).First() },
                    new Cocktail() { Name = "Bourbon Rocks", Receptacle = ctx.Receptacles.Where(ut => ut.Name.Equals("Small Glass")).First() }
                });

                ctx.SaveChanges();
            }
        }
        private void SeedCocktailIngredients()
        {
            using (var ctx = new CocktailDBContext())
            {
                // Cocktail_Ingredients
                ctx.Cocktail_Ingredients.AddRange(new List<Cocktail_Ingredient>()
                {
                    new Cocktail_Ingredient() { 
                        Quantity = 100, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("Crying Bastard")).First(), 
                        Ingredient = ctx.Alcohols.Where(ig => ig.Name.Equals("Bourbon")).First()},
                    new Cocktail_Ingredient() { 
                        Quantity = 10, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("Crying Bastard")).First(), 
                        Ingredient = ctx.Miscs.Where(ig => ig.Name.Equals("Onion")).First()},

                    new Cocktail_Ingredient() { 
                        Quantity = 100, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("White Russian")).First(), 
                        Ingredient = ctx.Alcohols.Where(ig => ig.Name.Equals("Kahluah")).First()},
                    new Cocktail_Ingredient() { 
                        Quantity = 50, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("White Russian")).First(), 
                        Ingredient = ctx.Alcohols.Where(ig => ig.Name.Equals("Vodka")).First()},
                    new Cocktail_Ingredient() { 
                        Quantity = 200, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("White Russian")).First(), 
                        Ingredient = ctx.Miscs.Where(ig => ig.Name.Equals("Milk")).First()},

                    new Cocktail_Ingredient() { 
                        Quantity = 100, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("Bourbon Rocks")).First(), 
                        Ingredient = ctx.Alcohols.Where(ig => ig.Name.Equals("Bourbon")).First()},
                    new Cocktail_Ingredient() { 
                        Quantity = 3, 
                        Cocktail=ctx.Cocktails.Where(c => c.Name.Equals("Bourbon Rocks")).First(), 
                        Ingredient = ctx.Miscs.Where(ig => ig.Name.Equals("Ice Cubes")).First()}
                });

                ctx.SaveChanges();
            }
        }

    
        public CocktailDBContext(): base()
        {
            // On initialization, the database is dropped before being recreated. This is useful for Development.
            Database.SetInitializer<CocktailDBContext>(new DropCreateDatabaseAlways<CocktailDBContext>());
        }

        public DbSet<Receptacle> Receptacles { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Misc> Miscs { get; set; }

        // https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-1-table-per-hierarchy-tph
        // didn't have time to properly implement inheritance, but I think this is the start of it, and then removing Alcohols and Miscs
        public class InheritanceMappingContext : DbContext
        {
            public DbSet<Ingredient> Ingredients { get; set; }
        }


        public DbSet<Cocktail_Ingredient> Cocktail_Ingredients { get; set; }

        internal void KillCocktail(Cocktail cocktail)
        {
            using (var ctx = new CocktailDBContext())
            {
                ctx.Cocktails.Remove(cocktail);
                ctx.SaveChanges();
            }
        }

        internal List<Cocktail> FullCocktails()
        {
            List<Cocktail> temp;
            List<Receptacle> rec;
            using (var ctx = new CocktailDBContext())
            {
                // Acquiring all Cocktails and their Cocktail_Ingredients
                temp = ctx.Cocktails.ToList<Cocktail>();
                temp.ForEach(c => c.Cocktail_Ingredients =
                    ctx.Cocktail_Ingredients.Where(ci => ci.Cocktail.Id.Equals(c.Id)).ToList<Cocktail_Ingredient>()
                    );
                // For some reason, Cocktail_Ingredients does not save Any information regarding the associated ingredient.
                // ..Except for that one time that I looked and it did. So I guess I must've done something Quite wrong.

                rec = ctx.Receptacles.ToList<Receptacle>();
                //  Receptacle is much simpler, and doesn't work either. :DDDD
            }

            return temp;
        }
    }
}

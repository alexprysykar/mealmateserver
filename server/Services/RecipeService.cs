using System.Collections.Generic;
using System.Linq;
using Server.Data;
using Server.Models;

namespace Server.Services
{
    public class RecipeService
    {
        private readonly MealMateContext _context;

        public RecipeService(MealMateContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.ToList();
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }
    }
}

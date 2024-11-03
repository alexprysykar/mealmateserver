using System.Collections.Generic;
using System.Linq;
using Server.Data;
using Server.Models;

namespace Server.Services
{
    public class RecipeService
    {
        private readonly MealMateContext _dbContext;

        public RecipeService(MealMateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipes.ToList();
        }

        public void AddRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
        }

        public void RemoveRecipe(int id)
        {
            var itemToDelte = _dbContext.Recipes
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (itemToDelte != null)
            {
                _dbContext.Recipes.Remove(itemToDelte);
                _dbContext.SaveChanges();
            }
        }
    }
}

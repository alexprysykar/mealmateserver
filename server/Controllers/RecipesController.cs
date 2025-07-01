using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetRecipes()
        {
            var recipes = _recipeService.GetAll();
            return Ok(recipes);
        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Recipe is null.");
            }

            _recipeService.AddRecipe(recipe);
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveRecipe([FromRoute] int id)
        {
            _recipeService.RemoveRecipe(id);
            return Ok();
        }
    }
}

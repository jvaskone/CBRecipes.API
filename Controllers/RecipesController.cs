using CBRecipes.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CBRecipes.API.Controllers
{
    [ApiController]    
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesDataStore _recipesDataStore;
        public RecipesController(RecipesDataStore recipesDataStore)
        {
            _recipesDataStore = recipesDataStore ?? throw new ArgumentNullException(nameof(recipesDataStore));
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetCities()
        {
            return Ok(_recipesDataStore.Recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeDto> GetRecipe(int id)
        {
            var recipeToReturn = _recipesDataStore.Recipes
            .FirstOrDefault(r => r.Id == id);

            if(recipeToReturn == null) {
                return NotFound();
            }

            return Ok(recipeToReturn);
        }
    }
}
using CBRecipes.API.Models;
using CBRecipes.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CBRecipes.API.Controllers
{
    [ApiController]    
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly ICBRecipesRepository _recipesRepository;
        public RecipesController(ICBRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository ?? throw new ArgumentNullException(nameof(recipesRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
        {
            var recipeEntities = await _recipesRepository.GetRecipesAsync();

            var results = new List<RecipeDto>();
            foreach (var recipeEntity in recipeEntities)
            {
                results.Add(new RecipeDto
                {
                    Id = recipeEntity.Id,
                    Name = recipeEntity.Name,
                    CategoryId = recipeEntity.CategoryId,
                    //Category = recipeEntity.Category,
                    Ingredients = recipeEntity.Ingredients,
                    Instructions = recipeEntity.Instructions                    
                });
            }
            return Ok(results);
            //return Ok(_recipesDataStore.Recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeDto> GetRecipe(int id)
        {
            // var recipeToReturn = _recipesDataStore.Recipes
            // .FirstOrDefault(r => r.Id == id);

            // if(recipeToReturn == null) {
            //     return NotFound();
            // }

            // return Ok(recipeToReturn);
            return Ok();
        }
    }
}
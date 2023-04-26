using CBRecipes.API.Models;
using CBRecipes.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CBRecipes.API.Controllers
{
    [ApiController]    
    [Route("api/categories")]
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly ICBRecipesRepository _recipesRepository;
        public RecipeCategoriesController(ICBRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository ?? throw new ArgumentNullException(nameof(recipesRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeCategoryDto>>> GetCategories()
        {
            // var recipeCategoryEntities = await _recipesRepository.GetRecipeCategoriesAsync();

            // var results = new List<RecipeCategoryDto>();
            // foreach (var recipeCategoryEntity in recipeCategoryEntities)
            // {
            //     results.Add(new RecipeCategoryDto
            //     {
            //         Id = recipeCategoryEntity.Id,
            //         Name = recipeCategoryEntity.Name,
            //     });
            // }
            // return Ok(results);
            return Ok();
        }

    }
}
using AutoMapper;
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
        private readonly IMapper _mapper;
        public RecipesController(ICBRecipesRepository recipesRepository,
            IMapper mapper)
        {
            _recipesRepository = recipesRepository ?? throw new ArgumentNullException(nameof(recipesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipes()
        {
            var recipeEntities = await _recipesRepository.GetRecipesAsync();

            return Ok(_mapper.Map<IEnumerable<RecipeDto>>(recipeEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
             var recipeToReturn = await _recipesRepository.GetRecipeAsync(id);
             return Ok(_mapper.Map<RecipeDto>(recipeToReturn));
        }
    }
}
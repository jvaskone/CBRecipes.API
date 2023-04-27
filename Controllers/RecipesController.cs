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

        [HttpGet("{id}", Name="GetRecipe")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
             var recipeToReturn = await _recipesRepository.GetRecipeAsync(id);
             if(recipeToReturn == null)
             {
                return NotFound();
             }
             return Ok(_mapper.Map<RecipeDto>(recipeToReturn));
        }

        [HttpPost("{recipe}")]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(            
            RecipeForCreationDto recipe)
        {
            var finalRecipe = _mapper.Map<Entities.Recipe>(recipe);
            _recipesRepository.AddRecipe(finalRecipe);

            await _recipesRepository.SaveChangesAsync();

            var createdRecipe = _mapper.Map<Models.RecipeDto>(finalRecipe);

            return CreatedAtRoute("GetRecipe",
                new 
                {
                    id = createdRecipe.Id
                },
                createdRecipe);
        }


        [HttpDelete("{recipeId}")]
        public async Task<ActionResult> DeleteRecipe(int recipeId) 
        {
           var recipeEntity = await _recipesRepository
                .GetRecipeAsync(recipeId);

            if(recipeEntity == null)
            {
                return NotFound();
            }            

            _recipesRepository.DeleteRecipe(recipeEntity);
            await _recipesRepository.SaveChangesAsync();
            return NoContent();
        }        
    }
}
using AutoMapper;
using CBRecipes.API.Models;
using CBRecipes.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CBRecipes.API.Controllers
{
    [ApiController]    
    [Route("api/categories")]
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly ICBRecipesRepository _repository;
        private readonly IMapper _mapper;
        public RecipeCategoriesController(ICBRecipesRepository repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeCategoryDto>>> GetCategories()
        {
            var categoryEntities = await _repository.GetRecipeCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<RecipeCategoryDto>>(categoryEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeCategoryDto>> GetCategory(int categoryId)
        {
            var categoryToReturn = await _repository.GetRecipeCategoryAsync(categoryId);
            return Ok(_mapper.Map<RecipeCategoryDto>(categoryToReturn));
        }
    }
}
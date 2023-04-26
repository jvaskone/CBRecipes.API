using CBRecipes.API.DbContexts;
using CBRecipes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CBRecipes.API.Services
{
    public class CBRecipesRepository : ICBRecipesRepository
    {
        private readonly CBRecipesContext _context;

        public CBRecipesRepository(CBRecipesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Recipe?> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(r => r.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipeCategories()
        {
            return await _context.RecipeCategories.ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }
    }
}
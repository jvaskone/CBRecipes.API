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

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(r => r.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<Recipe?> GetRecipeAsync(int recipeId, bool includeCategory)
        {
            if (!includeCategory) {
                return await GetRecipeAsync(recipeId);
            }
            return await _context.Recipes.Include(r => r.Category).Where(r => r.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipeCategoriesAsync()
        {
            return await _context.RecipeCategories.ToListAsync();
        }

        public async Task<RecipeCategory?> GetRecipeCategoryAsync(int categoryId)
        {
            return await _context.RecipeCategories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe); 
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public void AddCategory(RecipeCategory category)
        {
            _context.RecipeCategories.Add(category);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
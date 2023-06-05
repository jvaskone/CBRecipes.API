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
            return await _context.Recipes.OrderBy(r => r.CategoryId).ToListAsync();
        }

        public async Task<(IEnumerable<Recipe>, PaginationMetadata)> GetRecipesAsync(string? name, 
            string? searchQuery, int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = _context.Recipes as IQueryable<Recipe>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(r => r.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim().ToLower();
                collection = collection.Where(a => a.Name.ToLower().Contains(searchQuery)
                    ||(a.Category !=null && a.Category.Name.ToLower().Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(r => r.CategoryId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
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
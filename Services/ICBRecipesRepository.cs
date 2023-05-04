using CBRecipes.API.Entities;

namespace CBRecipes.API.Services
{
    public interface ICBRecipesRepository
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();

        Task<Recipe?> GetRecipeAsync(int recipeId);

        Task<IEnumerable<RecipeCategory>> GetRecipeCategoriesAsync();

        Task<RecipeCategory?> GetRecipeCategoryAsync(int categoryId);

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(Recipe recipe);

        void AddCategory(RecipeCategory category);

        Task<bool> SaveChangesAsync();
    }
}
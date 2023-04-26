using CBRecipes.API.Entities;

namespace CBRecipes.API.Services
{
    public interface ICBRecipesRepository
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();

        Task<Recipe?> GetRecipeAsync(int recipeId);

        Task<IEnumerable<RecipeCategory>> GetRecipeCategories();
    }
}
using CBRecipes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CBRecipes.API.DbContexts
{
    public class CBRecipesContext : DbContext
    {

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<RecipeCategory> RecipeCategories { get; set; } = null!;

        public CBRecipesContext(DbContextOptions<CBRecipesContext> options) : base(options)
        {
        }
        
    }
}
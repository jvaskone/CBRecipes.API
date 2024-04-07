using CBRecipes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CBRecipes.API.DbContexts
{
    public class CBRecipesContext : DbContext
    {

        public virtual DbSet<Recipe> Recipes { get; set; } = null!;

        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; } = null!;

        public CBRecipesContext(DbContextOptions<CBRecipesContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
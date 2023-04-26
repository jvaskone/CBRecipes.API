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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategory>().HasData(
                new RecipeCategory("Leves")
                {
                    Id = 1
                },
                new RecipeCategory("Főétel")
                {
                    Id = 2
                },
                new RecipeCategory("Köret, főzelék")
                {
                    Id = 3
                },
                new RecipeCategory("Desszert")
                {
                    Id = 4
                },
                new RecipeCategory("Torta")
                {
                    Id = 5
                },
                new RecipeCategory("Saláta")
                {
                    Id = 6
                },
                new RecipeCategory("Befőzés")
                {
                    Id = 7
                }
            );
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe("Húsleves")
                {
                    Id = 1,
                    CategoryId = 1,                  
                    Ingredients = "To be added..",
                    Instructions = "To be added..."
                },
                new Recipe("Csirkepaprikás")
                {
                    Id = 2,
                    CategoryId = 2,                  
                    Ingredients = "To be added...",
                    Instructions = "To be added..."
                }

            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
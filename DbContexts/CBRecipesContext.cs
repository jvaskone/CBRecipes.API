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
            base.OnModelCreating(modelBuilder);
        }
    }
}
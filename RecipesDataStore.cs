using CBRecipes.API.Models;

namespace CBRecipes.API
{
    public class RecipesDataStore
    {
        public List<RecipeDto> Recipes { get; set; }

        //public static RecipesDataStore Current { get; } = new RecipesDataStore();

        public RecipesDataStore()
        {
            Recipes = new List<RecipeDto>()
            {
                new RecipeDto()
                {
                    Id = 1,
                    Name = "HúsLeves",
                    Ingredients = "1 hús\n2 víz\n3 zöldség"
                },
                new RecipeDto()
                {
                    Id = 2,
                    Name = "Csirkepaprikás",
                    Ingredients = "hús+paprika"
                },
                new RecipeDto()
                {
                    Id = 3,
                    Name = "Fonott Kalács",
                    Ingredients = "tej, vaj, liszt, cukor, élesztő"
                }
            };
        }
    }
}
namespace CBRecipes.API.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;        

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }
    }
}
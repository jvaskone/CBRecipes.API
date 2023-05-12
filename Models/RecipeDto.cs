namespace CBRecipes.API.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public int CategoryId { get; set; }
        
        //public RecipeCategoryDto? Category { get; set; }   

        public String? Image { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }
    }
}
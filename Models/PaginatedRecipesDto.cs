namespace CBRecipes.API.Models
{
    public class PaginatedRecipesDto
    {        

        public IEnumerable<RecipeDto>? Recipes { get; set;}        
        
        public int TotalItemCount { get; set; } 
        
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
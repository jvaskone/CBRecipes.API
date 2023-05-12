using System.ComponentModel.DataAnnotations;

namespace CBRecipes.API.Models
{
    public class RecipeForCreationDto
    {
        
        [Required(ErrorMessage ="You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;    

        public int CategoryId { get; set; }

        public String? Image { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }
    }
}
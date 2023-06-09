using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBRecipes.API.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [ForeignKey("CategoryId")]
        public RecipeCategory? Category {get; set; }

        public int CategoryId { get; set; }

        public String? Image { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        public Recipe(string name)
        {
            Name = name;            
        }
    }
}
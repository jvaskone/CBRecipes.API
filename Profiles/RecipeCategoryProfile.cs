using AutoMapper;

namespace CBRecipes.API.Profiles
{
    public class RecipeCategoryProfile : Profile
    {
        public RecipeCategoryProfile()
        {
            CreateMap<Entities.RecipeCategory, Models.RecipeCategoryDto>();
        }   
    }
}
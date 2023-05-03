using AutoMapper;

namespace CBRecipes.API.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Entities.Recipe, Models.RecipeDto>();
            CreateMap<Models.RecipeForCreationDto, Entities.Recipe>();
            CreateMap<Models.RecipeForUpdateDto, Entities.Recipe>();
            CreateMap<Entities.Recipe, Models.RecipeForUpdateDto>();
        }   
    }
}
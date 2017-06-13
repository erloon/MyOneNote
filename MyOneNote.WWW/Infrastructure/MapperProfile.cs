using AutoMapper;
using MyOneNote.Data.Entity;
using MyOneNote.ViewModels;

namespace MyOneNote.WWW.Infrastructure
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryVM>()
                .ForMember(x=>x.UserProfileName,opt=>opt.MapFrom(dest=>dest.UserProfile.Id));
            CreateMap<Category, AddCategoryVM>();
            CreateMap<AddCategoryVM, Category>()
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<Project, ProjectVM>();
        }
    }
}
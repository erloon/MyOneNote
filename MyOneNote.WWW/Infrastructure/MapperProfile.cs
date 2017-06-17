using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOneNote.Data.Entity;
using MyOneNote.ViewModels.Dictionary;
using MyOneNote.ViewModels.Note;
using MyOneNote.WWW.Models;

namespace MyOneNote.WWW.Infrastructure
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryVM>()
                .ForMember(x=>x.UserProfileName,opt=>opt.MapFrom(dest=>dest.UserProfile.Id))
                .ForMember(x=>x.Name,opt=>opt.MapFrom(dest=>dest.Name))
                .ReverseMap();
            CreateMap<Category, AddCategoryVM>()
                .ForMember(x=>x.Name,opt=>opt.MapFrom(dest=>dest.Name))
                .ReverseMap();
            CreateMap<Project, ProjectVM>().ReverseMap();
            CreateMap<Project, AddProjectVM>().ReverseMap();
            CreateMap<Category, SelectedCategoryVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(dest => dest.Id))
                .ReverseMap();
            CreateMap<Project, SelectedProjectVM>()
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(dest => dest.Id))
                .ReverseMap();
            CreateMap<Category, SelectListItem>()
                .ForMember(x => x.Text, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(dest => dest.Id))
                .ReverseMap();
            CreateMap<Project, SelectListItem>()
                .ForMember(x => x.Text, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(dest => dest.Id))
                .ReverseMap();
            CreateMap<Tag, SelectListItem>()
                .ForMember(x => x.Text, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(dest => dest.Id))
                .ReverseMap();
            CreateMap<Note, ListNoteVM>()
                .ForMember(x => x.Id, opt => opt.MapFrom(dest => dest.Id))
                .ForMember(x => x.Description, opt => opt.MapFrom(dest => dest.ShortDescription))
                .ForMember(x=>x.Category,opt=>opt.MapFrom(dest=>dest.Category.Name))
                .ForMember(x=>x.CategoryId,opt=>opt.MapFrom(dest=>dest.Category.Id))
                .ReverseMap();

            CreateMap<Note, AddNoteVM>()
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(dest => dest.CategoryId))
                .ForMember(x => x.Content, opt => opt.MapFrom(dest => dest.Content))
                .ForMember(x => x.Description, opt => opt.MapFrom(dest => dest.ShortDescription))
                .ForMember(x => x.ProjectId, opt => opt.MapFrom(dest => dest.ProjectId))
                .ForMember(x => x.Title, opt => opt.MapFrom(dest => dest.Title));

            CreateMap<AddNoteVM, Note>()
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(dest => dest.CategoryId))
                .ForMember(x => x.Content, opt => opt.MapFrom(dest => dest.Content))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(dest => dest.Description))
                .ForMember(x => x.ProjectId, opt => opt.MapFrom(dest => dest.ProjectId))
                .ForMember(x => x.Title, opt => opt.MapFrom(dest => dest.Title));
        }
    }
    }

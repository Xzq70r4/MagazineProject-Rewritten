namespace MagazineProject.Web.Models.Area.Users.UserProfiles
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Models.InputModels.Base.User.Interface;

    public class UserProfileViewModel : IMapFrom<User>, IHaveCustomMappings, IProfile
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [AllowHtml]
        public string InfoContent { get; set; }

        public DateTime TimeCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserProfileViewModel>()
                .ForMember(m => m.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.UserName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(u => u.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(u => u.LastName))
                .ForMember(m => m.InfoContent, opt => opt.MapFrom(u => u.InfoContent))
                .ForMember(m => m.TimeCreated, opt => opt.MapFrom(u => u.CreatedOn))
                .ReverseMap();
        }
    }
}
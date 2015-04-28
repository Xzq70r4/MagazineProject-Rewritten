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
                .ForMember(m => m.TimeCreated, opt => opt.MapFrom(u => u.CreatedOn))
                .ReverseMap();
        }
    }
}
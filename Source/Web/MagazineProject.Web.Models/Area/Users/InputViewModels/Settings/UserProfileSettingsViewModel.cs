namespace MagazineProject.Web.Models.Area.Users.InputViewModels.Settings
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;
    using MagazineProject.Web.Infrastructure.ValidationAttribute;
    using MagazineProject.Web.Models.Area.Users.Interface;

    public class UserProfileSettingsViewModel : IMapFrom<User>, IHaveCustomMappings, IProfile
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [UIHint("SingleLineText")]
        public string Email { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "First Name")]
        [UIHint("SingleLineText")]

        public string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "Last Name")]
        [UIHint("SingleLineText")]
        public string LastName { get; set; }

        [AllowHtml]
        [MinLength(50)]
        [MaxLength(1000)]
        [Display(Name = "Info Presentation")]
        [UIHint("tinymce_full")]
        public string InfoContent { get; set; }

        [UIHint("UploadImage")]
        [Display(Name = "Image")]
        [FileTypes("jpg,jpeg,png")]
        [FileSize(4096)]
        [NotMapped]
        public HttpPostedFileBase UploadedImage { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserProfileSettingsViewModel>()
                .ForMember(m => m.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(u => u.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(u => u.LastName))
                .ForMember(m => m.InfoContent, opt => opt.MapFrom(u => u.InfoContent))
                .ReverseMap();
        }
    }
}
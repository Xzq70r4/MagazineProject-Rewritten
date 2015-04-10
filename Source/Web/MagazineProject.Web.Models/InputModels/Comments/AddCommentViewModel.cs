namespace MagazineProject.Web.Models.InputModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using MagazineProject.Data.Models;
    using MagazineProject.Web.Infrastructure.Mapping;

    public class AddCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int PostId { get; set; }

        [AllowHtml]
        [Required]
        [MinLength(20)]
        [MaxLength(25000)]
        [DataType("tinymce_full")]
        public string Content { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, AddCommentViewModel>()
                .ForMember(c => c.PostId, opt => opt.MapFrom(c => c.PostId))
                .ForMember(c => c.Content, opt => opt.MapFrom(c => c.Content));
        }
    }
}
namespace MagazineProject.Web.Models.Area.Users.Interface
{
    public interface IProfile
    {
        string Email { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string InfoContent { get; set; }
    }
}
namespace MagazineProject.Common
{
    public class GlobalConstants
    {
        //Roles
        public const string User = "User";
        public const string Writer = "Writer";
        public const string Moderator = "Moderator";
        public const string Admin = "Admin";

        //Password
        public const string DefaultPassword = "123456";

        //Images
        public const string UserImagePath = "/Migrations/Imgs/user.jpg";
        public const string PostImagePath = "/Migrations/Imgs/post.jpg";
        public const string SliderPostCoverImagePath = "/Migrations/Imgs/slider_cover.jpg";
        public const string ThumbnailPostCoverImagePath = "/Migrations/Imgs/thumbnail_cover.jpg";


        //Controllers
        public const string SettingsController = "Settings";
        public const string CommentsController = "Comments";

        public const string UserPostsController = "UserPosts";
        public const string UserCommentsController = "UserComments";

        //Controler Action
        public const string GetAllPostsAction = "GetAllPosts";
        public const string GetPostsByCategoryAction = "GetPostsByCategory";


    }
}

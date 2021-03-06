﻿namespace MagazineProject.Common
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
        public const string SliderPostCoverImagePath = "/Migrations/Imgs/slider_cover.jpg";
        public const string ThumbnailPostCoverImagePath = "/Migrations/Imgs/thumbnail_cover.jpg";

        public const int ThumbnailPostCoverImageWidth = 350;
        public const int ThumbnailPostCoverImageHeight = 200;
        public const int SliderPostCoverImageWidth = 1200;
        public const int SliderPostCoverImageHigth = 500;
        public const int UserImageWidth = 350;
        public const int UserImageHeight = 230;

        //Site Constant
        public const string SiteConstSlider = "Post Slider";
        public const string SiteConstVideoPost = "Post With Video";

        //Controllers
        public const string HomeController = "Home";
        public const string CommentsController = "Comments";

        public const string UserPostsController = "UserPosts";
        public const string UserCommentsController = "UserComments";

        //Controler Action
        public const string PostsByCategoryAction = "PostsByCategory";
        public const string EditAction = "Edit";
        public const string AddAction = "Add";

        //Message
        public const string SuccessMessage = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Success!</strong> Successfully {0}.</div> ";
        public const string FailMessage = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>Fail!</strong> Not Successfully{0}</div>";
    }
}

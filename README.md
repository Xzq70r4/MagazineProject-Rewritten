#MagazineProject  -  ASP.NET MVC 5 Application
========
MagazineProject is simple Web Magazine application.

Everyone can free read magazine`s posts without log in. Every post have category, author and comments. Post and comment list are with ajax paging.

Easy Logging. Have facebook and google login or regular.

Have search for posts with autocomplete.

Create example database. When start app for first time. 

**Regular Users** can free read posts, comments and see another profiles. After logging they can add comments and change their profile settings.

## Roles ##

**Writers** have all rights like Regular Users, but can add post (after logging). But post waiting for approve from Moderators or Admins.

**Moderators** have all rights like Writers, but can editing all posts and comments. They can add approve or hide(delete) posts or comments.

**Admins** have all rights like Writers. They can editing users, add or delete from Role. Admin adding category or hide with them posts and post`s comments. Admin can editing number of posts on slider(home page) and number of showing post with video url (on home page).

##ASP NET MVC 5 application powered by:##
- [ASP.NET MVC]( http://www.asp.net/mvc/mvc5) - Repository Pattern + Unit of work + Services layer
- [Microsoft SQL Server](http://www.microsoft.com/en-us/server-cloud/products/sql-server/)
- [Entity Framework]( https://entityframework.codeplex.com) – ORM framework - Code First
- [Ninject](http://www.ninject.org/) - Dependency injector for .NET
- [Automapper](http://automapper.org/) - A convention - based object - object mapper
- [Twitter Bootstrap](http://getbootstrap.com/)
- [jQuery](http://jquery.com/)
- [Grid.Mvc](http://gridmvc.codeplex.com/)
- [PagedList](https://github.com/TroyGoode/PagedList)

Development Environment: Microsoft Visual Studio 2013
##Accounts
- Username: Admin , Password: 123456, Role: Admin
- Username: Moderator , Password: 123456, Role: Moderator
- Username: Writer , Password: 123456, Role: Writer
- Username: User, Password: 123456, Role: No role (normal user)

## Screenshots ##

[Magazine Project - Image Gallery](https://www.dropbox.com/sh/ub1qi31r65cbjnl/AACD-W_NCgexSHoL6PdSQQwia?dl=0)

**Home Page**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/home-page-top-side.jpg" /></p>

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/home-page.jpg" /></p>

**Posts by Category**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/posts-by-category-top-side.jpg" /></p>

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/posts-by-category.jpg" /></p>

**Post detail page**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/post-detail-page-top.jpg" /></p>

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/post-detail-page-buttom.jpg" /></p>

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/posts-detail-page-comment.jpg" /></p>

**Profile**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/profile.jpg" /></p>

**Grid(all grids like this)**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/user-grid.jpg" /></p>

**Role Manager**

<p align="center"><img src="https://raw.githubusercontent.com/Xzq70r4/MagazineProject-Rewritten/master/Images/role-manager.jpg" /></p>

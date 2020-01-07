using RealBlog.DAL;
using RealBlog.Helpers;
using RealBlog.Models;
using RealBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealBlog.Controllers
{
    public class ProfileController : Controller
    {

        private readonly BikerBlogDBContext _context = new BikerBlogDBContext();
        private static ProfileViewModel profileView;
        private static PostViewModel postView ;
        private static List<Post> posts;
        // GET: Profile
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Edit(ProfileViewModel model, HttpPostedFileBase imageData)
        {
            profileView = model;
            Update();
            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = _context.Users.First(user => user.Id == userId);
            if (ModelState.IsValid)
            {
                //Проверка на совпадение паролей
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError(string.Empty, "Пароли не совпадают!");
                    return View("Index", model);
                }
                var userInDBNick = _context.Users.FirstOrDefault(user => user.NickName == model.NickName);
                //Проверка на уникальность никнейма
                if (userInDBNick != null && userInDBNick.Id!=ProfileViewModel.Id)
                {
                    ModelState.AddModelError(string.Empty, "Такой никнейм уже зарегистрирован");
                    return View("Index", model);
                }
                if (imageData != null)
                {
                    model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);
                }
                else
                {
                    model.PhotoUrl = userInDb.PhotoUrl;
                }
                
                    userInDb.NickName = model.NickName;
                    userInDb.FirstName = model.FirstName;
                    userInDb.LastName = model.LastName;
                    userInDb.BikeSecification = model.BikeSecification;
                    userInDb.ContactInfo = model.ContactInfo;
                    userInDb.Hobbies = model.Hobbies;
                    if (model.Password != null && model.Password.Length > 0)
                        userInDb.PasswordConfirm = model.Password;
                    if (model.PhotoUrl != null)
                        userInDb.PhotoUrl = model.PhotoUrl;
              
                    _context.SaveChanges();
                    Session["UserNick"] = model.NickName;
                    Session["UserPhotoUrl"] = userInDb.PhotoUrl;
                
                return View("Index", model);
            }
            return View("Index", model);
        }
        public ActionResult Index(int id)
        {
            User model = _context.Users.First(user => user.Id == id);
            profileView = new ProfileViewModel
            {
                NickName = model.NickName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhotoUrl = model.PhotoUrl,
                BikeSecification = model.BikeSecification,
                ContactInfo = model.ContactInfo,
                Hobbies = model.Hobbies
            };
            postView = new PostViewModel();
            ProfileViewModel.Id = model.Id;
            posts = _context.Posts.OrderByDescending(c => c.Date).Where(post => post.Author.Id == model.Id).ToList();
            Update();
            return View();
        }
        public PartialViewResult ProfileInfo(ProfileViewModel model)
        {
            return PartialView("Profile", model);
        }
        public PartialViewResult PostInfo(PostViewModel model)
        {
            return PartialView("Post", model);
        }
        
        [HttpPost]
        //  [Authorize]
        public ActionResult AddPost(PostViewModel model, HttpPostedFileBase imageData)
        {
            postView = model;
            Update();
                if (imageData == null)
                {
                    ModelState.AddModelError(string.Empty, "Не прикреплена картинка!");
                    return View("Index", model);
                }
                model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);
                model.Date = DateTime.Now;
                var userId = Convert.ToInt32(Session["UserId"]);

                Post post = new Post
                {
                    Author = _context.Users.FirstOrDefault(c => c.Id == userId),
                    Date = DateTime.Now,
                    Text = model.Text,
                    PhotoUrl = ImageSaveHelper.SaveImage(imageData)
                };

                _context.Posts.Add(post);
                _context.SaveChanges();
               
                ViewBag.Posts.Add(post);
                return RedirectToAction("Index", new { id = userId});
          
        }
        private void Update()
        {
            ViewBag.ProfileView = profileView;
            ViewBag.PostView = postView;
            ViewBag.Posts = posts;
        }
    }
}
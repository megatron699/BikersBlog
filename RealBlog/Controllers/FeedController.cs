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
    public class FeedController : Controller
    {
        private readonly BikerBlogDBContext _context = new BikerBlogDBContext();
        // GET: Feed
        public ActionResult Index()
        {
            Update();
            return View();
        }
        [HttpGet]
        public ActionResult Search(SearchViewModel model)
        {
            var posts = _context.Posts.OrderByDescending(c => c.Date).Where(post => post.Text.Contains(model.SearchString) || post.Author.NickName.Contains(model.SearchString)).ToList();
            ViewBag.Posts = posts;
            return View("Index");
        }
        [HttpPost]
      //  [Authorize]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {
            if (Session["UserId"] == null)
            {
                // return RedirectToAction("Index", "Home");
                return new HttpUnauthorizedResult("Авторизуйтесь для добавления поста");
            }
            Update();
                if (imageData == null)
                {
                    ModelState.AddModelError(string.Empty, "Не прикреплена картинка!");
                   
                }
                if(model.Text == null) { ModelState.AddModelError(string.Empty, "Не прикреплен текст!"); }
                if (!ModelState.IsValid) { return View("Index", model); }
                model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);
                model.Date = DateTime.Now;
                var userId = Convert.ToInt32(Session["UserId"]);
                var userInDb = _context.Users.FirstOrDefault(c => c.Id == userId);
                if (userInDb == null) { throw new Exception("Пользователь не найден в БД"); }
                model.Author = userInDb;
                
                _context.Posts.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Feed");

        }
        private void Update()
        {
            var posts = _context.Posts.OrderByDescending(c => c.Date).ToList();
            ViewBag.Posts = posts;
        }
    }
}
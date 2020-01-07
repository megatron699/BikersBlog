using RealBlog.DAL;
using RealBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BikerBlogDBContext _context = new BikerBlogDBContext();
        public ActionResult Index()
        {

            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Feed");
            }
            else
            {
                var cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    Session["UserId"] = cookie["UserId"];
                    Session["UserNick"] = cookie["UserNick"];
                    return RedirectToAction("Index", "Feed");
                }
            }
            return View();
            
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Feed");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    var userInDb = _context.Users.FirstOrDefault(user => user.NickName == model.Nickname && user.Password == model.Password);
                    if (userInDb != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Nickname, model.Remembering);
                        Session["UserId"] = userInDb.Id.ToString();
                        Session["UserNick"] = userInDb.NickName;
                        Session["UserPhotoUrl"] = userInDb.PhotoUrl;
                        if (model.Remembering)
                        {
                            HttpCookie userInfo = new HttpCookie("UserInfo");
                            userInfo["UserId"] = userInDb.Id.ToString();
                            userInfo["UserNick"] = userInDb.NickName.ToString();
                            userInfo.Expires = DateTime.Now.AddYears(1);
                            Response.Cookies.Add(userInfo);
                        }
                        return RedirectToAction("Index", "Feed");
                    }
                    else { ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль"); }
                }

                return View("Index", model);
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
           
            var cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                var newCookie = new HttpCookie("UserInfo");
                newCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(newCookie);

            }
            return RedirectToAction("Index");
        }
    }
}
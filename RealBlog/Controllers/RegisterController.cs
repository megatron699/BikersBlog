using RealBlog.DAL;
using RealBlog.Helpers;
using RealBlog.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealBlog.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BikerBlogDBContext _context = new BikerBlogDBContext();
        // GET: Register
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Feed");
            }
            else
            return View();
        }
        [HttpPost]
        public ActionResult Register(User model, HttpPostedFileBase imageData)
        {
            if(ModelState.IsValid)
            {
                //Проверка на совпадение паролей
                if (model.Password != model.PasswordConfirm) { ModelState.AddModelError(string.Empty, "Пароли не совпадают!"); }
                var userInDBNick = _context.Users.FirstOrDefault(user => user.NickName == model.NickName);
                var userInDBMail = _context.Users.FirstOrDefault(user => user.Email == model.Email);
                //Проверка на уникальность никнейма
                if(userInDBNick != null)
                {
                    ModelState.AddModelError(string.Empty, "Такой никнейм уже зарегистрирован");
                }
                //Проверка на уникальность почты
                if (userInDBMail != null)
                {
                    ModelState.AddModelError(string.Empty, "Такая почта уже зарегистрирована!");
                }
                if(!ModelState.IsValid)
                {
                    return View("Index", model);
                }
                //Сохраняем пользователя
                if(imageData!=null)
                {
                    model.PhotoUrl = ImageSaveHelper.SaveImage(imageData);
                }

                _context.Users.Add(model);
                _context.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.NickName,false);
                Session["UserId"] = model.Id.ToString();
                Session["UserNick"] = model.NickName;
                Session["UserPhotoUrl"] = model.PhotoUrl;
                return RedirectToAction("Index", "Feed");
               // return RedirectToAction("Index", "Feed");
            }
            return View("Index",model);
        }
    }
}
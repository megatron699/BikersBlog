using System.ComponentModel.DataAnnotations;

namespace RealBlog.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Псевдоним")]
        [MaxLength(20), Required(ErrorMessage = "Введите псевдоним")]
        public string Nickname { get; set; }
        [Display(Name ="Пароль")]
        [MaxLength(20), Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [Display(Name ="Запомнить пароль")]
        public bool Remembering { get; set; }
    }
}
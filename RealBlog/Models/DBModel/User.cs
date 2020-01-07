using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealBlog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ошибка псевдонима"), MinLength(3, ErrorMessage ="Слишком короткий псевдоним"), MaxLength(20, ErrorMessage ="Слишком длинный псевдоним")]
        [Display(Name = "Псевдоним*")]
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{3,20}", ErrorMessage = "Псевдоним некорректен")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Введите пароль"), MinLength(6, ErrorMessage = "Слишком маленький пароль!"), MaxLength(20, ErrorMessage = "Слишком длинный пароль!")]
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{6,20}", ErrorMessage = "Пароль некорректен")]
        [Display(Name ="Пароль*")]
        public string Password { get; set; }
        [NotMapped]      
        [Display(Name = "Подтверждение пароля*")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Введите почту*"), MaxLength(31)]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage ="Такая почта уже зарегистрирована")]
        public string Email { get; set; }
        [MaxLength(260)]
        [Display(Name = "Фото")]
        public string PhotoUrl { get; set; }
        [Display(Name = "Имя")]
        [MaxLength(31)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [MaxLength(31)]
        public string LastName { get; set; }
        [MaxLength(255)]
        [Display(Name = "Контактная информация")]
        public string ContactInfo { get; set; }
        [MaxLength(255)]
        [Display(Name = "ТТХ мотоцикла")]
        public string BikeSecification { get; set; }
        [MaxLength(255)]
        [Display(Name = "Увлечения")]
        public string Hobbies { get; set; }

     
    }
}
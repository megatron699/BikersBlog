using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealBlog.Models.ViewModel
{
    public class ProfileViewModel
    {
        [Key]
        static public int Id { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{3,20}", ErrorMessage = "Псевдоним некорректен")]
        [Display(Name = "Псевдоним*")]
        [MinLength(3, ErrorMessage = "Слишком короткий псевдоним"), MaxLength(20, ErrorMessage = "Слишком длинный псевдоним")]
        public string NickName { get; set; }
        [MinLength(6, ErrorMessage = "Слишком маленький пароль!"), MaxLength(20, ErrorMessage = "Слишком длинный пароль!")]
        [Display(Name = "Пароль*")]
        [RegularExpression(@"^(?=.*[A-Za-zА-Яа-я])[A-Za-zА-Яа-я\d_]{6,20}", ErrorMessage = "Пароль некорректен")]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Подтверждение пароля*")]
        public string PasswordConfirm { get; set; }
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
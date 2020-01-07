using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealBlog.Models.ViewModel
{
    public class PostViewModel
    {
      ///<summary>
        ///Ключ сущности
        ///</summary>
        [Key]
        public int Id { get; set; }
        ///<summary>
        ///Дата публикации поста
        ///</summary>
        public DateTime Date { get; set; }
        ///<summary>
        ///Текст поста
        ///</summary>>
        [Display(Name ="Введите текст")]
        [MaxLength(4095)]
        [Required(ErrorMessage = "Введите текст")]
        public string Text { get; set; }
        ///<summary>
        ///Фото
        ///</summary>
        [MaxLength(260)]
        [Display(Name = "Прикрепить изображение")]
        public string PhotoUrl { get; set; }
        ///<summary>
        ///Автор
        ///</summary>
        public virtual User Author { get; set; }
    }
}
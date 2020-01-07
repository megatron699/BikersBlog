using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Модель машины"), Required(ErrorMessage ="Модель не задана")]
        public string ModelName { get; set; }
        [Display(Name = "Максимальная скорость"), Required(ErrorMessage ="Не указана максимальная скорость"), Range(100,500)]
        public int MaxSpeed { get; set; }
    }
}
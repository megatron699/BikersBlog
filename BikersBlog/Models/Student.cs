using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikersBlog.Models
{
    public class Student
    { 
        [Display(Name="Имя"), Required(ErrorMessage = "Имя не задано")]   
        
        public string Name { get; set; }
        [Display(Name = "Возраст"), Range(14, 100)]
        
        public int Age { get; set; }
        [Display(Name = "День рождения"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime Birthday { get; set; }
        [Display(Name = "Группа"), MaxLength(5)]
        
        public string Group { get; set; }
        [Display(Name = "Отчислен")]
        public bool IsSendDown { get; set; }
        [Display(Name = "Фото"), Required(ErrorMessage = "Фото не задано")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Университет")]
        public Univercity Univercity { get; set; }

        //todo дата рождения DateTime
        //группа String
        //Отчислен bool
    }
}
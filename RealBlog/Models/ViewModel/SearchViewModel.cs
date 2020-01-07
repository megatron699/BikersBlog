using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealBlog.Models.ViewModel
{
    public class SearchViewModel
    {
        [MaxLength(255)]
        public string SearchString { get; set; }
    }
}
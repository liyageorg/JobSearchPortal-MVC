using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{
    public class login
    {
        [Required(ErrorMessage = "enter username")]
        public string username { get; set; }

        public string password { get; set; }

        public string login_status { get; set; }

        public string msg { get; set; }
    }
}
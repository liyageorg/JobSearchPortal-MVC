using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{
    public class cmpins
    {

        [Required(ErrorMessage = "enter name")]
        public string cname { set; get; }

        [EmailAddress(ErrorMessage = "enter valid email")]
        public string cemail { set; get; }


        [Required(ErrorMessage = "enter name")]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string cphone { set; get; }

        public string cdesc { set; get; }

        [Required(ErrorMessage = "enter address")]
        public string caddress { set; get; }

        public string cusername { set; get; }

        public string cpassword { set; get; }

        public string msg { set; get; }



    }
}
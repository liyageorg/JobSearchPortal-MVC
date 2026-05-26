using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{

    public class CheckBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class userins
    {
        public List<CheckBoxListHelper> MyFavouriteQual { get; set; }
        public string[] selectedQual { get; set; }
        public int uid { set; get; }

        [Required(ErrorMessage = "enter name")]
        public string uname { set; get; }

        [Required(ErrorMessage = "enter name")]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string uphone { set; get; }

        [EmailAddress(ErrorMessage = "enter valid email")]
        public string uemail { set; get; }


        [Required(ErrorMessage = "enter address")]
        public string uaddress { set; get; }

        public string uquali { set; get; }

        public string uexp { set; get; }

        public string uskill { set; get; }

        public string ustatus { set; get; }

        public string username { set; get; }

        public string password { set; get; }

        public string msg { set; get; }



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{
    public class chome
    {
        public int job_id { get; set; }

        public int cmp_id { get; set; }

        [Required(ErrorMessage = "Enter Job Title")]
        public string job_title { get; set; }

        [Required(ErrorMessage = "Enter Job Description")]
        public string job_desc { get; set; }

        [Required(ErrorMessage = "Enter Location")]
        public string location { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        public string salary { get; set; }

        [Required(ErrorMessage = "Enter Qualification")]
        public string qualification { get; set; }

        [Required(ErrorMessage = "Enter Experience")]
        public string experience { get; set; }

        [Required(ErrorMessage = "Select Last Date")]
        public DateTime last_date { get; set; }

        public string job_status { get; set; }

        public string msg { get; set; }
    }
}
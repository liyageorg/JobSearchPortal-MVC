using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{
    public class applyjob
    {
        internal string cv;
        internal DateTime lastdate;

        public int apply_id { get; set; }

        public int user_id { get; set; }

        public int job_id { get; set; }

        public DateTime apply_date { get; set; }

        public string resume { get; set; }

        public string apply_status { get; set; }

        // For Resume Upload
        public HttpPostedFileBase resumeFile { get; set; }

        // For displaying job details
  
        public string job_title { get; set; }

        public string job_desc { get; set; }

        public string location { get; set; }

        public string qualification { get; set; }

        public string experience { get; set; }

        public string salary { get; set; }

        public string msg { get; set; }
    }
}

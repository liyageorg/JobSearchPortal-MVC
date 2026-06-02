using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOB_SEARCH.Models
{
    public class jobsearch
    {
        public jobsearch()
        {
            selectjob = new List<jobList>();
            insertse = new jobList();
        }

        public jobList insertse { get; set; }
        public List<jobList> selectjob { get; set; }
    }

    public class joblist
    {
        public int job_id { get; set; }
        public int cmp_id { get; set; }
        public string job_title { get; set; }
        public string job_desc { get; set; }
        public string location { get; set; }
        public string salary { get; set; }
        public string skills { get; set; }
        public string qualification { get; set; }
        public string experience { get; set; }
        public DateTime last_date { get; set; }
        public string job_status { get; set; }
        public string searchdata { get; set; }

        
    }
}

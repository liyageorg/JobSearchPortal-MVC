using System;
using System.Linq;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class uhomeController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();

        public ActionResult uhome_pageload()
        {
            return View(GetJobList());
        }

        private uhome GetJobList()
        {
            var joblists = new uhome();

            var jobs = objdb.job_posting
                            .Where(j => j.job_status == "available")
                            .ToList();

            foreach (var j in jobs)
            {
                var jobobj = new jobList();

                jobobj.job_id = j.job_id;
                jobobj.cmp_id = Convert.ToInt32(j.cmp_id);
                jobobj.job_title = j.job_title;
                jobobj.job_desc = j.job_desc;
                jobobj.location = j.location;
                jobobj.salary = j.salary;
                jobobj.qualification = j.quali;
                jobobj.experience = j.exp;
                jobobj.last_date = Convert.ToDateTime(j.last_date);
                jobobj.job_status = j.job_status;

                joblists.selectjob.Add(jobobj);
            }

            return joblists;
        }

        public ActionResult ApplyNow(int id)
        {
            Session["job_id"] = id;
            return RedirectToAction("Applyjob_pageload", "Applyjob");
        }
    }
}
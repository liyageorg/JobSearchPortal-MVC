using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class applyjobController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();

        public ActionResult applyjob_pageload(int job_id)
        {
            applyjob obj = new applyjob();

            Session["Job_id"] = job_id;

            int userid = Convert.ToInt32(Session["user_id"]);

            var i = objdb.sp_appliid(job_id, userid).FirstOrDefault();

            if (i == 1)
            {
                TempData["msg"] = "You have already applied for this job";
                return RedirectToAction("uhome_pageload", "uhome");
            }

            var job = objdb.job_posting.FirstOrDefault(j => j.job_id == job_id);

            if (job != null)
            {
                obj.job_id = job.job_id;
                obj.job_title = job.job_title;
                obj.job_desc = job.job_desc;
                obj.location = job.location;
                obj.salary = job.salary;
                obj.qualification = job.quali;
                obj.experience = job.exp;   
            }

            return View(obj);
        }

        [HttpPost]
        public ActionResult applyjob_click(HttpPostedFileBase file, applyjob clsobj)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);

                string folderPath = Server.MapPath("~/ApplicationResume");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string pa = Path.Combine(folderPath, fname);
                file.SaveAs(pa);

                clsobj.resume = "~/ApplicationResume/" + fname;
            }

            clsobj.apply_date = DateTime.Today;
            clsobj.user_id = Convert.ToInt32(Session["user_id"]);
            clsobj.job_id = Convert.ToInt32(Session["Job_id"]);
            clsobj.apply_status = "apply";

            objdb.sp_appliinsert(
                clsobj.user_id,
                clsobj.job_id,
                clsobj.apply_date,
                clsobj.resume,
                clsobj.apply_status
            );

            TempData["msg"] = "Applied successfully";
            return RedirectToAction("uhome_pageload", "uhome");
        }
    }
}
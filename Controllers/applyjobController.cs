using System;
using System.Collections.Generic;
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
        // GET: applyjob
        public ActionResult applyjob_pageload(int job_id)
        {
            applyjob obj = new applyjob();
            Session["Job_id"] = job_id;

            int userid = Convert.ToInt32(Session["user_id"]);
            int jobids = Convert.ToInt32(Session["Job_id"]);

            var i = objdb.sp_appliid(jobids, userid).FirstOrDefault();

            if (i == 1)
            {
                TempData["msg"] = "You have already applied for this job";
                return RedirectToAction("uhome_pageload", "uhome");
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
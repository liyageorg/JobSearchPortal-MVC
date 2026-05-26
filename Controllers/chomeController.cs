using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class chomeController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();
        // GET: chome
        public ActionResult chome_Pageload()
        {
            return View(new chome());
        }

        [HttpPost]
        public ActionResult chome_click(chome clsobj)
        {
            if (ModelState.IsValid)
            {
                objdb.sp_jobpost(
                    Convert.ToInt32(Session["uid"]),
                    clsobj.job_title,
                    clsobj.job_desc,
                    clsobj.location,
                    clsobj.salary,
                    clsobj.qualification,
                    clsobj.experience,
                    clsobj.last_date,
                    "available"
                );

                clsobj.msg = "Successfully inserted";
                return View("chome_PageLoad", clsobj);
            }

            return View("chome_PageLoad", clsobj);
        }
    }
}
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class loginController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();
        // GET: login
        public ActionResult login_pageload()
        {
            return View();
        }

        public ActionResult userhome()
        {
            return View();
        }

        public ActionResult companyhome()
        {
            return View();
        }


        public ActionResult login_click(JOB_SEARCH.Models.login objcls)
        {
            if (ModelState.IsValid)
            {
                var val = objdb.sp_countid(objcls.username, objcls.password).First();
                if (val == 1)
                {
                    var uid = objdb.sp_loginid(objcls.username, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = objdb.sp_logstatus(objcls.username, objcls.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("uhome_pageload", "uhome");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("chome_pageload", "chome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid username and password";
                    return View("login_pageload", objcls);
                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid login";
                return View("login_pageload", objcls);
            }
            return View("login_pageload", objcls);
        }

    }
}
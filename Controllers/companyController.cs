using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class companyController : Controller
    {

        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();
        // GET: company
        public ActionResult insertcompany_pageload()
        {
            return View();
        }

        public ActionResult insertcompany_click(cmpins objcls)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = objdb.sp_maxid().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }

                objdb.sp_cmpreg(regid, objcls.cname, objcls.cemail, objcls.cphone, objcls.cdesc, objcls.caddress);
                objdb.sp_logininsert(regid, objcls.cusername, objcls.cpassword, "company");
                objcls.msg = "success";
                return View("insertcompany_pageload", objcls);
            }
            return View("insertcompany_pageload", objcls);
        }

    }
}
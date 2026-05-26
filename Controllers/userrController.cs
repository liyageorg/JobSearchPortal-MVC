using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOB_SEARCH.Models;

namespace JOB_SEARCH.Controllers
{
    public class userrController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();
        // GET: userr
        public ActionResult insertuser_pageload()
        {
            userins user = new userins();
            user.MyFavouriteQual = getQualificationData();
            return View(user);
        }

        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true },
                new CheckBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false },
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false },
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false },
                new CheckBoxListHelper{Value="BTECH",Text="BTECH",IsChecked=false },
            };
            return sts;
        }
        public ActionResult insertuser_click(userins objcls)
        {
            if (ModelState.IsValid)
            {

                var quid = string.Join(",", objcls.selectedQual);
                objcls.uquali= quid;
                objcls.MyFavouriteQual = getQualificationData();

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

                objdb.sp_userreg(regid, objcls.uname, objcls.uphone, objcls.uemail, objcls.uaddress, objcls.uquali, objcls.uexp, objcls.uskill, "Active");
                objdb.sp_logininsert(regid, objcls.username, objcls.password, "user");
                objcls.msg = "success";
                return View("insertuser_pageload", objcls);
            }

            else
            {
                objcls.MyFavouriteQual = getQualificationData();
            }
            return View("insertuser_pageload", objcls);
        }

    }
}
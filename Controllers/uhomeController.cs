using System;
using System.Linq;
using System.Web.Mvc;
using JOB_SEARCH.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JOB_SEARCH.Controllers
{
    public class uhomeController : Controller
    {
        JOB_SEARCHEntities objdb = new JOB_SEARCHEntities();

        public ActionResult uhome_pageload()
        {
            return View(GetJobList());
        }

        private jobsearch GetJobList()
        {
            var joblists = new jobsearch();

            var jobs = objdb.job_posting
                            .Where(j => j.job_status == "available")
                            .ToList();

            int userid = Convert.ToInt32(Session["user_id"]);

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

                var applied = objdb.sp_appliid(jobobj.job_id, userid).FirstOrDefault();

                if (applied == 1)
                {
                    jobobj.msg = "Applied";
                }
                else
                {
                    jobobj.msg = "Apply Now";
                }

                joblists.selectjob.Add(jobobj);
            }

            return joblists;
        }

        public ActionResult ApplyNow(int id)
        {
            Session["job_id"] = id;
            return RedirectToAction("applyjob_pageload", "applyjob");
        }

        public ActionResult searchjob_click(jobsearch clsobj)
        {
            string qry = "";

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and exp like '%" + clsobj.insertse.experience + "%'";
            }

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.qualification))
            {
                qry += " and quali like '%" + clsobj.insertse.qualification + "%'";
            }

            if (!string.IsNullOrWhiteSpace(clsobj.insertse.location))
            {
                qry += " and location like '%" + clsobj.insertse.location + "%'";
            }

            return View("uhome_pageload", getdata(clsobj, qry));
        }

        private jobsearch getdata(jobsearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["JOB_SEARCHConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                var joblist = new jobsearch();

                while (dr.Read())
                {
                    var jobcls = new jobList();

                    jobcls.job_id = Convert.ToInt32(dr["job_id"]);
                    jobcls.cmp_id = Convert.ToInt32(dr["cmp_id"]);
                    jobcls.job_title = dr["job_title"].ToString();
                    jobcls.job_desc = dr["job_desc"].ToString();
                    jobcls.location = dr["location"].ToString();
                    jobcls.salary = dr["salary"].ToString();
                    jobcls.qualification = dr["quali"].ToString();
                    jobcls.experience = dr["exp"].ToString();
                    jobcls.last_date = Convert.ToDateTime(dr["last_date"]);
                    jobcls.job_status = dr["job_status"].ToString();

                    joblist.selectjob.Add(jobcls);
                }

                con.Close();
                return joblist;
            }
        }

    }
}
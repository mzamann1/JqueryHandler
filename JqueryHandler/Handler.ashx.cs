using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace JqueryHandler
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    /// 


        public class Std
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Class { get; set; }
    }
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string rpp = context.Request.QueryString["rpp"];
            string page = context.Request.QueryString["page"];



                 if (context.Request.Path == "/Handler.ashx/AddStudent")
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                student newstd = JsonConvert.DeserializeObject<student>(strJson);
                student newstd1 = new student
                {
                    std_Fname = newstd.std_Fname,
                    std_Lname = newstd.std_Lname,
                    std_class = newstd.std_class,

                };

                using (SampleDataContext db = new SampleDataContext())
                {
                    var student = db.spGetResponseStudent(newstd1.std_Fname, newstd1.std_Lname, newstd1.std_class);
                    context.Response.Write(JsonConvert.SerializeObject(student));

                }


            }
                 if (context.Request.Path == "/Handler.ashx/DeleteStd")
            {
                if (context.Request.Params["id"] != null)
                {
                    int.TryParse(context.Request.Params["id"], out int id);
                    using (SampleDataContext db = new SampleDataContext())
                    {
                        var n = db.spDltStd(id);

                        context.Response.Write(JsonConvert.SerializeObject(n));
                    }
                }
            }
                 if (context.Request.Path == "/Handler.ashx/GetGuardianById")
                {
                    if (context.Request.Params["id"] != null)
                    {
                        int.TryParse(context.Request.Params["id"], out int id);
                        using (SampleDataContext db = new SampleDataContext())
                        {
                            context.Response.Write(JsonConvert.SerializeObject(db.spGetGuardianByStdId(id)));
                        }
                    }
                }
                 if (context.Request.Path == "/Handler.ashx/ViewStudents")
                {
                    if (context.Request.Params["page"] != null && context.Request.Params["rpp"] != null)
                    // if (page != null && rpp != null)
                    {
                        page = context.Request.Params["page"];
                        rpp = context.Request.Params["rpp"];
                        int.TryParse(page, out int val);
                        int.TryParse(rpp, out int r);

                        using (SampleDataContext db = new SampleDataContext())
                        {
                            var students = db.spindexWork(val, r);
                            int? a = 0;
                            var total = db.spGetAllCount(ref a);
                            // context.Response.Write(total);
                            var result = JsonConvert.SerializeObject(students, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }
                        );
                            context.Response.Write(result);
                        }


                    }

                    else
                    {
                        using (SampleDataContext db = new SampleDataContext())
                        {
                            context.Response.Write(JsonConvert.SerializeObject(db.spindexWork(1, 10)));
                        }
                    }
                }
                 if (context.Request.Path == "/Handler.ashx/AddGuardian")
            {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                var g= JsonConvert.DeserializeObject<guardian>(strJson);

                if (g.std_id==0) {

                    using (SampleDataContext db = new SampleDataContext())
                    {
                        db.spAddGuardian(g.g_Fname, g.g_Lname, g.g_Address,null);
                    }
                }
                else
                {
                    using (SampleDataContext db = new SampleDataContext())
                    {
                        db.spAddGuardian(g.g_Fname, g.g_Lname, g.g_Address, g.std_id);
                    }
                }
            }
            }
        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
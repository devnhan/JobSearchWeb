using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAPISimple.Models;

namespace TestAPISimple.Controllers
{
    public class HomeController : Controller
    {
        private DBConnection db = new DBConnection();
        public ActionResult Index(Recruiter recruiter)
        {
            // Trả về view hoặc thực hiện logic để lấy và hiển thị danh sách tin tuyển dụng
            List<Recruitment> recruitments = db.GetRecruitmentsFromDatabase();
            return View(recruitments);
        }

        //// phương thức giả lập lấy danh sách tuyển dụng (ví dụ)
        //public actionresult register(recruiter recruiter)
        //{
        //    string response = db.recruiterregister(recruiter);

        //    return json(response, jsonrequestbehavior.allowget);

        //}
    }
}

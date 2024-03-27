using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAPISimple.Models;

namespace TestAPISimple.Controllers
{
    public class RecruitmentController : Controller
    {
        private DBConnection db = new DBConnection();
        // GET: Recruitment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListRecruitments()
        {
            // Trả về view hoặc thực hiện logic để lấy và hiển thị danh sách tin tuyển dụng
            List<Recruitment> recruitments = db.GetRecruitmentsFromDatabase();
            return View(recruitments);

        }
        // GET: Recruitment/Create
        public ActionResult CreateRecruitment()
        {
            return View();
        }

        // POST: Recruitment/Create
        [HttpPost]
        public ActionResult CreateRecruitment(Recruitment recruitment)
        {
            if (ModelState.IsValid)
            {
                db.AddRecruitmentToDatabase(recruitment);
                return RedirectToAction("ListRecruitments");
            }

            return View(recruitment);
        }

        public ActionResult EditRecruitment(long id)
        {
            // Lấy thông tin tuyển dụng từ database dựa trên id
            Recruitment recruitment = db.GetRecruitmentById(id);

            if (recruitment == null)
            {
                // Xử lý trường hợp không tìm thấy tuyển dụng
                return HttpNotFound();
            }

            return View(recruitment);
        }

        [HttpPost]
        public ActionResult UpdateRecruitment(Recruitment updatedRecruitment)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện cập nhật thông tin tuyển dụng trong database
                db.UpdateRecruitment(updatedRecruitment);
                return RedirectToAction("ListRecruitments");
            }

            return View("EditRecruitment", updatedRecruitment);
        }

        public ActionResult DeleteRecruitment(long id)
        {
            Recruitment recruitment = db.GetRecruitmentById(id);

            if (recruitment == null)
            {
                return HttpNotFound();
            }

            return View(recruitment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedRecruitment(long id)
        {
            Recruitment recruitment = db.GetRecruitmentById(id);

            if (recruitment != null)
            {
                db.DeleteRecruitment(id);
                return RedirectToAction("ListRecruitments");
            }

            return HttpNotFound();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAPISimple.Models;
using Newtonsoft.Json;

namespace TestAPISimple.Controllers
{
    public class CandidateController : Controller
    {
        BAL bal = new BAL();
        private DBConnection db = new DBConnection();
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Candidates candidate) 
        {
            string response = bal.CandidateRegister(candidate);
            //candidate.Role = "Candidate";

            //return Json(response, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Login", "Candidate");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Candidates candidate)
        {
            string response = bal.CandidateLogin(candidate.CandidatesEmail, candidate.CandidatesPassword);

            // Kiểm tra xem đăng nhập có thành công không
            if (response == "Đăng nhập thành công")
            {
                // Lấy ID của ứng viên từ cơ sở dữ liệu hoặc từ một nguồn khác phù hợp
                long candidateId = db.GetCandidateIdByEmail(candidate.CandidatesEmail);

                // Lưu ID của ứng viên vào session
                SetCurrentCandidateId(candidateId);

                // Chuyển hướng đến trang nộp CV
                return RedirectToAction("Index", "Home");
            }

            // Đăng nhập thất bại, có thể xử lý lỗi hoặc hiển thị thông báo lỗi
            return Json(response, JsonRequestBehavior.AllowGet);
            //return Json(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SubmitCV()
        {
            // Kiểm tra xem ứng viên có đăng nhập không
            long candidateId = GetCurrentCandidateId();
            if (candidateId == 0)
            {
                // Nếu không đăng nhập, có thể chuyển hướng đến trang đăng nhập hoặc hiển thị thông báo lỗi
                // Ví dụ:
                return RedirectToAction("Login", "Candidate");
            }

            // Lấy thông tin tuyển dụng từ cơ sở dữ liệu để hiển thị trong trang nộp CV
            List<Recruitment> recruitments = db.GetRecruitmentsFromDatabase();

            // Bạn có thể chuyển danh sách tuyển dụng đến view để hiển thị trong dropdown hoặc các phần khác của form
            //ViewBag.Recruitments = recruitments;

            // Tạo đối tượng CurriculumVitae để lưu thông tin từ form
            CurriculumVitae cv = new CurriculumVitae();

            return View(cv);
        }

        [HttpPost]
        public ActionResult SubmitCV(CurriculumVitae cv)
        {
            if (ModelState.IsValid)
            {
                // Giả sử ứng viên đã đăng nhập, hãy lấy ID của ứng viên
                long candidateId = GetCurrentCandidateId();

                // Đặt ID của ứng viên trong đối tượng CV
                cv.CandidatesID = candidateId;

                // Lưu CV vào cơ sở dữ liệu
                bal.SubmitCurriculumVitae(cv);

                return RedirectToAction("SubmitCV", "Candidate"); // Chuyển hướng đến trang chủ hoặc trang khác phù hợp
            }

            // Nếu trạng thái mô hình không hợp lệ, quay lại trang nộp với các lỗi
            return RedirectToAction("Index", "Home");
        }

        

        private void SetCurrentCandidateId(long candidateId)
        {
            Session["CurrentCandidateId"] = candidateId;
        }

        private long GetCurrentCandidateId()
        {
            // Triển khai logic để lấy ID của ứng viên hiện tại (ví dụ, từ danh tính người dùng đã đăng nhập)
            object currentCandidateId = Session["CurrentCandidateId"];

            if (currentCandidateId != null && currentCandidateId is long)
            {
                return (long)currentCandidateId;
            }

            // Trả về một giá trị mặc định hoặc xử lý lỗi tùy thuộc vào logic của bạn
            return 0;
        }


    }
}
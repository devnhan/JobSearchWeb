using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TestAPISimple.Models
{
    public class BAL
    {
        DBConnection db = new DBConnection();
        public string CandidateRegister(Candidates candidate)
        {
            return db.CandidateRegister(candidate);

        }
        public string CandidateLogin(string email, string password)
        {
            return db.CandidateLogin(email, password);

        }

        public string RecruiterRegister(Recruiter recruiter)
        {

            return db.RecruiterRegister(recruiter);

        }

        public string RecruiterLogin(string email, string password)
        {
            return db.RecruiterLogin(email, password);

        }

        public void SubmitCurriculumVitae(CurriculumVitae cv)
        {
            // Gọi phương thức trong lớp DBConnection để thêm CurriculumVitae vào cơ sở dữ liệu
            new DBConnection().AddCurriculumVitaeToDatabase(cv);
        }
    }
}
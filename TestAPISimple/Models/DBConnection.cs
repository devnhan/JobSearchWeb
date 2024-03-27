using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace TestAPISimple.Models
{
    public class DBConnection
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt = null;

        public string CandidateRegister(Candidates candidate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Candidates (CandidatesEmail, CandidatesName, CandidatesPassword) VALUES (@Email, @Name, @Password)", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", candidate.CandidatesEmail);
                        cmd.Parameters.AddWithValue("@Name", candidate.CandidatesName);
                        cmd.Parameters.AddWithValue("@Password", candidate.CandidatesPassword);
                        //cmd.Parameters.AddWithValue("@IsValid", candidate.IsValid); // Assuming IsValid is a boolean property in Candidate class
                        //cmd.Parameters.AddWithValue("@DateOfBirth", candidate.DateOfBirth);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            return "Đăng ký thành công";
                        else
                            return "Đăng ký thất bại";
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi ở đây
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return "Đăng ký thất bại";
                }
            }
        }

        public string CandidateLogin(string email, string password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CandidatesID FROM Candidates WHERE CandidatesEmail = @Email AND CandidatesPassword = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    var candidateId = cmd.ExecuteScalar();

                    if (candidateId != null)
                    {
                        // Đăng nhập thành công
                        return "Đăng nhập thành công";
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        return "Đăng nhập thất bại";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return "Đăng nhập thất bại";
            }
        }

        public long GetCandidateIdByEmail(string email)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CandidatesID FROM Candidates WHERE CandidatesEmail = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    var candidateId = cmd.ExecuteScalar();

                    if (candidateId != null)
                    {
                        return Convert.ToInt64(candidateId);
                    }
                }
            }

            // Trả về 0 hoặc một giá trị mặc định khác nếu không tìm thấy ứng viên
            return 0;
        }


        public string RecruiterRegister(Recruiter recruiter)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Recruiter (RecruiterEmail, RecruiterName, RecruiterPassword) VALUES (@Email, @Name, @Password)", con))
                    {
                        cmd.Parameters.AddWithValue("@Email", recruiter.RecruiterEmail);
                        cmd.Parameters.AddWithValue("@Name", recruiter.RecruiterName);
                        cmd.Parameters.AddWithValue("@Password", recruiter.RecruiterPassword);
                        //cmd.Parameters.AddWithValue("@IsValid", candidate.IsValid); // Assuming IsValid is a boolean property in Candidate class
                        //cmd.Parameters.AddWithValue("@DateOfBirth", candidate.DateOfBirth);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            return "Đăng ký thành công";
                        else
                            return "Đăng ký thất bại";
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi ở đây
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return "Đăng ký thất bại";
                }
            }
        }

        public string RecruiterLogin(string email, string password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT RecruiterID FROM Recruiter WHERE RecruiterEmail = @Email AND RecruiterPassword = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    var recruiterId = cmd.ExecuteScalar();

                    if (recruiterId != null)
                    {
                        // Đăng nhập thành công
                        return "Đăng nhập thành công";
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        return "Đăng nhập thất bại";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return "Đăng nhập thất bại";
            }
        }

        public List<Recruitment> GetRecruitmentsFromDatabase()
        {
            List<Recruitment> recruitments = new List<Recruitment>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Recruitment", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recruitment recruitment = new Recruitment
                            {
                                RecruitmentID = Convert.ToInt64(reader["RecruitmentID"]),
                                //JobPostingDay = Convert.ToDateTime(reader["JobPostingDay"]),
                                Career = Convert.ToString(reader["Career"]),
                                Skill = Convert.ToString(reader["Skill"]),
                                CompanyName = Convert.ToString(reader["CompanyName"])
                                // Add other properties based on your database schema
                            };

                            recruitments.Add(recruitment);
                        }
                    }
                }
            }

            return recruitments;
        }

        public void AddRecruitmentToDatabase(Recruitment recruitment)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Recruitment (Career, Skill, CompanyName) VALUES (@Career, @Skill, @CompanyName)", con))
                {
                    //cmd.Parameters.AddWithValue("@JobPostingDay", recruitment.JobPostingDay);
                    cmd.Parameters.AddWithValue("@Career", recruitment.Career);
                    cmd.Parameters.AddWithValue("@Skill", recruitment.Skill);
                    cmd.Parameters.AddWithValue("@CompanyName", recruitment.CompanyName);
                    // Add other parameters based on your database schema

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Recruitment GetRecruitmentById(long id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Recruitment WHERE RecruitmentID = @RecruitmentID", con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Recruitment recruitment = new Recruitment
                            {
                                RecruitmentID = Convert.ToInt64(reader["RecruitmentID"]),
                                //JobPostingDay = Convert.ToDateTime(reader["JobPostingDay"]),
                                Career = Convert.ToString(reader["Career"]),
                                Skill = Convert.ToString(reader["Skill"]),
                                CompanyName = Convert.ToString(reader["CompanyName"]),

                                // Add other properties based on your database schema
                            };

                            return recruitment;
                        }
                    }
                }
            }

            return null; // Trả về null nếu không tìm thấy tuyển dụng với ID tương ứng
        }

        public void UpdateRecruitment(Recruitment updatedRecruitment)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Recruitment SET Career = @Career, Skill = @Skill, CompanyName = @CompanyName WHERE RecruitmentID = @RecruitmentID", con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", updatedRecruitment.RecruitmentID);
                    cmd.Parameters.AddWithValue("@Career", updatedRecruitment.Career);
                    cmd.Parameters.AddWithValue("@Skill", updatedRecruitment.Skill);
                    cmd.Parameters.AddWithValue("@CompanyName", updatedRecruitment.CompanyName);
                    // Add other parameters based on your database schema

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRecruitment(long id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Recruitment WHERE RecruitmentID = @RecruitmentID", con))
                {
                    cmd.Parameters.AddWithValue("@RecruitmentID", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddCurriculumVitaeToDatabase(CurriculumVitae cv)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CurriculumVitae (Name, ApplicantPosition, Email, PhoneNumber, CandidatesID) VALUES (@Name, @ApplicantPosition, @Email, @PhoneNumber, @CandidatesID)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", cv.Name);
                    cmd.Parameters.AddWithValue("@ApplicantPosition", cv.ApplicantPosition);
                    cmd.Parameters.AddWithValue("@Email", cv.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", cv.PhoneNumber);
                    cmd.Parameters.AddWithValue("@CandidatesID", cv.CandidatesID);
                    //cmd.Parameters.AddWithValue("@SkillID", cv.SkillID);
                    //cmd.Parameters.AddWithValue("@WorkExperienceID", cv.WorkExperienceID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
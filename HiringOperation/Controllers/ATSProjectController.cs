using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using HiringOperation.Models;

using HiringOperation.Mainlogic;
using NuGet.Protocol.Plugins;
using System.Net.Security;
using System.Net.Mail;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

namespace HiringOperation.Controllers
{
    public class ATSProjectController : Controller
    {

      

        [HttpGet]
        public ActionResult Model()
        {
            return View(ModuleData.GetAllData());
        }
        [HttpPost]
        public ActionResult Model(string Hall_ticket_no, string Remarks, int Score, string To)
        {
            string LoginName =  HttpContext.Session.GetString("LoginName");

            string Status = "";
            string Result = "";
            if (Score >= 60)
            {
                Status = "Waiting For L2 Interview";
                Result = "Dear Student,Congratulations you are Selected In First Round";
            }
            else
            {

                Status = "L1 Rejected";
                Result = "Dear Student, you are Rejected In First Round";
            }

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_interview_records_std", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Hall_ticket_no", Hall_ticket_no);

                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@Score", Score);
                cmd.Parameters.AddWithValue("@Status", Status);

                cmd.Parameters.AddWithValue("@LoginName", LoginName);
                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress("pavanpuppala1616@gmail.com");
                mail.Subject = "Interview Result";
                string Body = Result;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("pavanpuppala1616@gmail.com", "yvddbdfpddgilocn"); // Enter senders User name and password       
                smtp.EnableSsl = true;
                smtp.Send(mail);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return RedirectToAction("Model", "ATSProject");
                }
                return View();
            }
        }

        







            [HttpGet]
        public IActionResult PopupInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PopupInsert(PopUp obj)
        {

            if (ModelState.IsValid)
            {
                bool res = MainLogic.DataPopup(obj);


            }
            else
            {
                return View(obj);
            }
            return View();
        }

    
        [HttpGet]
        public IActionResult Module1()
        {



               return View(ModuleData.GetAllData());
            

        }
        //[HttpPost]
        //public IActionResult Module1(PopUp obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        bool res = MainLogic.DataPopup(obj);


        //    }
        //    else
        //    {
        //        return View(obj);
        //    }
        //    return View();
        //}



            public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("password", "The username or password is incorrect");
                DataTable dt = new DataTable();
                dt = Hiring_bl.LoginPage(obj);
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("UserName", dt.Rows[0]["EmailID"].ToString());
                    HttpContext.Session.SetString("LoginName", dt.Rows[0]["FirstName"].ToString());
                    HttpContext.Session.SetString("Time", System.DateTime.Now.ToShortTimeString());
                    return RedirectToAction("Index", "ATSProject");
                }
                else
                {
                    return View();
                }
            }
            return View(obj);
        }

        [HttpGet]
    
        public IActionResult REGISTER()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult REGISTER(Model1 OBJ)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = MainLogic.Insertdata(OBJ);

                if (res == true)
                {

                    return View("LOGIN");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }

        //---------------- editing the user data----------------
        //-------------------------------------------------------

        public IActionResult EDIT(String? RegisterId)
        {
            return View(EditDelete.GetDataByID((string)RegisterId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EDIT(Model1 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = EditDelete.UpdateUsers(obj);
                if (res == true)
                {
                    return RedirectToAction("UserData");
                }
                else
                {
                    return View(obj);
                }
            }
            return View();
        }
        //public IActionResult EDIT(String? RegisterId)
        //{
        //    return View(EditDelete.GetDataByROLLNO((String)RegisterId));
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EDIT(Model1 OBJ)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool res = EditDelete.UPDATEDATABYROLLNO(OBJ);
        //        if (res == true)
        //        {
        //            return RedirectToAction("UserData", "ATSProject");
        //        }
        //        else
        //        {
        //            return View(EditDelete.UPDATEDATABYROLLNO(OBJ));
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        public IActionResult DELETEDATA(String? RegisterId)
        {
            if (ModelState.IsValid)
            {
                bool res = EditDelete.DELETEDataByROLLNO((String)RegisterId);
                if (res == true)
                {
                    return RedirectToAction("UserData", "ATSProject");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View((String)RegisterId);
            }
        }
        //---------------------
        //---------------------

        public IActionResult UserData()
        {
            return View(DisplayingUserdata.GetDataUser());
        }
        public IActionResult Totaldata()
        {
            return View(Student.GetData4());
        }
        public IActionResult Condition()
        {
            return View(Student.GetData1());
        }
        public ActionResult Model2()
        {
            return View(MODELDATA2.GetData6());
        }

        public IActionResult Totaldata1()
        {
            return View(Student.GetData2());
        }

        [HttpGet]
        public IActionResult ManageSTD()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManageSTD(List<IFormFile> PostedFiles, HiringSTD obj)
        {
            foreach (IFormFile PostedFile in PostedFiles)
            {
                string fileName = Path.GetFileName(PostedFile.FileName);
                string type = PostedFile.ContentType;
                byte[] bytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    PostedFile.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
                string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionstr))
                {
                    SqlCommand cmd = new SqlCommand("sp_hiringSTD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hall_ticket_no", obj.Hall_ticket_no);
                    cmd.Parameters.AddWithValue("@Name_of_the_student", obj.Name_of_the_student);
                    cmd.Parameters.AddWithValue("@Emailid", obj.Emailid);
                    cmd.Parameters.AddWithValue("@Dob", Convert.ToDateTime(obj.Dob));
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@PH_No", Convert.ToInt64(obj.PH_No));
                    cmd.Parameters.AddWithValue("@Aadhar_no", Convert.ToInt64(obj.Aadhar_no));
                    cmd.Parameters.AddWithValue("@School_Name", obj.School_Name);
                    cmd.Parameters.AddWithValue("@ssc_Year_of_Pass_out", Convert.ToInt32(obj.ssc_Year_of_Pass_out));
                    cmd.Parameters.AddWithValue("@Ssc_Aggregate", obj.Ssc_Aggregate);
                    cmd.Parameters.AddWithValue("@Junior_College_Name", obj.Junior_College_Name);
                    cmd.Parameters.AddWithValue("@inter_Year_of_Pass_out", Convert.ToInt32(obj.inter_Year_of_Pass_out));
                    cmd.Parameters.AddWithValue("@inter_Aggregate", obj.inter_Aggregate);
                    cmd.Parameters.AddWithValue("@Engineering_College_Name", obj.Engineering_College_Name);
                    cmd.Parameters.AddWithValue("@Branch", obj.Branch);
                    cmd.Parameters.AddWithValue("@Btech_Year_of_Pass_out", Convert.ToInt32(obj.Btech_Year_of_Pass_out));

                    cmd.Parameters.AddWithValue("@Total_backlogs", Convert.ToInt32(obj.Total_backlogs));
                    cmd.Parameters.AddWithValue("@Graduation_Aggregate", obj.Graduation_Aggregate);
                    cmd.Parameters.AddWithValue("@Fathers_name", obj.Fathers_name);
                    cmd.Parameters.AddWithValue("@Fathers_occupation", obj.Fathers_occupation);
                    cmd.Parameters.AddWithValue("@Permanent_address", obj.Permanent_address);
                    cmd.Parameters.AddWithValue("@Present_address", obj.Present_address);
                    cmd.Parameters.AddWithValue("@Fathers_Mobile_No", obj.Fathers_Mobile_No);
                    cmd.Parameters.AddWithValue("@Mothers_Name", obj.Mothers_Name);
                    cmd.Parameters.AddWithValue("@Mothers_Occupation", obj.Mothers_Occupation);
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@ContentType", type);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View();
        }



        // forgetpassword
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult Forgetpassword()
        {
            return View();
        }
        public IActionResult Forgetpassword(Model1 OBJ)
        {
            Random rand = new Random();
            HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());
            bool result = SendEmail(OBJ.EmailID);
            if (result == true)
            {

                return RedirectToAction("FORGOTPASSWORDOtp", "ATSProject");
            }
            return View();
        }
        [HttpGet]
        public IActionResult FORGOTPASSWORDOtp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FORGOTPASSWORDOtp(OtpModel obj)
        {

            if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("SETTINGNEWPASSWORD", "ATSProject");
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult SETTINGNEWPASSWORD()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SETTINGNEWPASSWORD(ForgetPasswordModel OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = DisplayingUserdata.UPDATEDATABYEMAILID(OBJ);
                if (res == true)
                {
                    return RedirectToAction("Login", "ATSProject");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }



        public bool SendEmail(string receiver)
        {
            bool chk = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("pavanpuppala1616@gmail.com");
                mail.To.Add(receiver);
                mail.IsBodyHtml = true;
                mail.Subject = "OTP";
                mail.Body = "Your OTP is :" + HttpContext.Session.GetString("OTP");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("pavanpuppala1616@gmail.com", "yvddbdfpddgilocn");
                client.EnableSsl = true;
                client.Send(mail);
                chk = true;
            }
            catch (Exception)
            {
                throw;
            }
            return chk;
        }



        [HttpGet]
        public IActionResult VerifyOtp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOtp(OtpModel obj)
        {
            if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("Index", " ATSProject");
            }
            else
            {
                return View();
            }
        }
        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---------------------------------sending Mail_____________



        [HttpGet]
        public IActionResult SendingMail()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SendingMail(HiringOperation.Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("pavanpuppala1616@gmail.com", "yvddbdfpddgilocn"); // Enter seders User name and password       
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }

    }
}

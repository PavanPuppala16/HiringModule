using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Formats.Asn1.AsnWriter;

namespace HiringOperation.Mainlogic
{
    public class MainLogic
    {
        public static bool Modeldata(string Hall_ticket_no, string Remarks, int Score)
        {
            bool res = false;
            string LoginName = "";
            string Status = "";
            if (Score >= 60)
            {
                Status = "Waiting For L2 Interview";
                LoginName = "Admin";
            }
            else
            {
                Status = "L1 Rejected";
                LoginName = "user";
            }
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into ModalPopUp(Hall_ticket_no,Remarks,Score,Status,LoginName) values(@Hall_ticket_no,@Remarks,@Score,@Status,@LoginName)", con);

                        cmd.Parameters.AddWithValue("@Hall_ticket_no", Hall_ticket_no);

                        cmd.Parameters.AddWithValue("@Remarks", Remarks);
                        cmd.Parameters.AddWithValue("@Score", Score);
                        cmd.Parameters.AddWithValue("@Status", Status);

                        cmd.Parameters.AddWithValue("@LoginName", LoginName);


                        int x = cmd.ExecuteNonQuery();
                        if (x > 0)
                        {
                            return res = true;
                        }
                        else
                        {
                            return res = false;
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }

        public static bool DataPopup(PopUp obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_InsertPopup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hall_ticket_no", obj.Hall_ticket_no);
                    cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                    cmd.Parameters.AddWithValue("@Score", obj.Score);
                    cmd.Parameters.AddWithValue("@DateOfL1Exam", obj.DateOfL1Exam);
                 
                   

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }

        public static bool Insertdata(Model1 obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_INSERT_TBL_ADMIN1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", obj.userid);
                    cmd.Parameters.AddWithValue("@RegisterId", obj.RegisterId);
                    cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);

                    cmd.Parameters.AddWithValue("@Dob", Convert.ToDateTime(obj.Dob));
                    cmd.Parameters.AddWithValue("@Role", obj.Role);

                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@InsertionDate", Convert.ToDateTime(obj.InsertionDate));


                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
       
    }
}

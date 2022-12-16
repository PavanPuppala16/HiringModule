using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace HiringOperation.Mainlogic
{
    public class DisplayingUserdata
    {
      

        public static List<Model1> GetDataUser()
            {
                List<Model1> obj = new List<Model1>();
                var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
                string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionstr))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SP_Display_userData", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj.Add(new Model1
                        {
                            userid = Convert.ToInt32(dr["userid"].ToString()),
                            RegisterId = dr["RegisterId"].ToString(),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),

                            EmailID = dr["EmailID"].ToString(),


                            Gender = dr["Gender"].ToString(),
                            Dob = Convert.ToDateTime(dr["Dob"].ToString()),


                        });

                    }
                    return obj;
                }
            }

        public static bool UPDATEDATABYEMAILID(ForgetPasswordModel OBJ)
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
                    SqlCommand cmd = new SqlCommand("sp_ResetPassword1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMAILID", OBJ.Emailid);
                    cmd.Parameters.AddWithValue("@PASSWORD", OBJ.Password);
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

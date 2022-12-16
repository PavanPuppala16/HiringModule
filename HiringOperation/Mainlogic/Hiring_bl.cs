using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class Hiring_bl
    {
        public static DataTable LoginPage(LoginViewModel obj)
        {
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AdminLogin_Project", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }
    }
}

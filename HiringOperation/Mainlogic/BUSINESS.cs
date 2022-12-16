using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class BUSINESS
    {
        public static DataTable login(AdminLogin OBJ)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_Login_TBL_ADMIN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", OBJ.EmailID);
                cmd.Parameters.AddWithValue("@Password", OBJ.Password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}


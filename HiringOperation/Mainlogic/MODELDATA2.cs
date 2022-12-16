using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class MODELDATA2
    {
        public static List<Module2> GetData6()
        {
            List<Module2> obj = new List<Module2>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_DATA_POPUP1", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new Module2
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString()),
                        Hall_ticket_no = dr["Hall_ticket_no"].ToString(),
                        Name_of_the_student = dr["Name_of_the_student"].ToString(),
                        Emailid = dr["Emailid"].ToString(),
                        //PH_No = Convert.ToInt32(dr["PH_No"].ToString()),
                        Engineering_College_Name = dr["Engineering_College_Name"].ToString(),
                        Btech_Year_of_Pass_out = Convert.ToInt32(dr["Btech_Year_of_Pass_out"].ToString()),
                        Total_backlogs = Convert.ToInt32(dr["Total_backlogs"].ToString()),
                        // Remarks = dr["Remarks"].ToString(),
                        // Score = Convert.ToInt32(dr["Score"].ToString()),
                        status = dr["status"].ToString(),
                        Date = Convert.ToDateTime(dr["Date"].ToString()),
                        LoginName = dr["LoginName"].ToString(),



                    });

                }
                return obj;
            }
        }




    }
}

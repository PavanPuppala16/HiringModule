using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class ModuleData
    {

     

        public static List<HiringSTD> GetAllData()
        {



            List<HiringSTD> obj = new List<HiringSTD>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from HiringSTD where Ssc_Aggregate>60.00 and inter_Aggregate>60.00 and Total_backlogs=0 and Graduation_Aggregate>60.00 ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new HiringSTD
                        {

                            Hall_ticket_no = dr["Hall_ticket_no"].ToString(),
                            Name_of_the_student = dr["Name_of_the_student"].ToString(),
                            Emailid = dr["Emailid"].ToString(),
                            PH_No = Convert.ToInt64(dr["PH_No"].ToString()),
                            Engineering_College_Name = dr["Engineering_College_Name"].ToString(),
                            Btech_Year_of_Pass_out = Convert.ToInt32(dr["Btech_Year_of_Pass_out"].ToString()),
                            Total_backlogs = Convert.ToInt32(dr["Total_backlogs"].ToString()),
                            Status= dr["Status"].ToString(),

                        }
                        );
                }





                return obj;





            }
        }
        public static List<HiringSTD> GetData1()
        {
            List<HiringSTD> obj = new List<HiringSTD>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_HiringSTD1_Important", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new HiringSTD
                    {
                        Sno = Convert.ToInt32(dr["Sno"].ToString()),
                        // Hall_ticket_no= dr["Hall_ticket_no"].ToString(),
                        Name_of_the_student = dr["Name_of_the_student"].ToString(),
                        Emailid = dr["Emailid"].ToString(),
                        Dob = Convert.ToDateTime(dr["Dob"].ToString()),
                        // Gender = dr["Gender"].ToString(),
                        PH_No = Convert.ToInt64(dr["PH_No"].ToString()),
                        //Aadhar_no = Convert.ToInt32(dr["Aadhar_no"].ToString()),
                        //School_Name = dr["School_Name"].ToString(),
                        //ssc_Year_of_Pass_out = Convert.ToInt32(dr["ssc_Year_of_Pass_out"].ToString()),
                        Ssc_Aggregate = dr["Ssc_Aggregate"].ToString(),
                        //Junior_College_Name = dr["Junior_College_Name"].ToString(),
                        // inter_Year_of_Pass_out= Convert.ToInt32(dr["inter_Year_of_Pass_out"].ToString()),
                        inter_Aggregate = dr["inter_Aggregate"].ToString(),
                        //    Engineering_College_Name = dr["Engineering_College_Name"].ToString(),
                        //   Branch = dr["Branch"].ToString(),
                        //   Btech_Year_of_Pass_out = Convert.ToInt32(dr["Btech_Year_of_Pass_out"].ToString()),
                        Total_backlogs = Convert.ToInt32(dr["Total_backlogs"].ToString()),
                        Graduation_Aggregate = dr["Graduation_Aggregate"].ToString(),
                        Fathers_name = dr["Fathers_name"].ToString(),
                        //   Fathers_occupation = dr["Fathers_occupation"].ToString(),
                        //    Permanent_address = dr["Permanent_address"].ToString(),
                        //    Present_address = dr["Present_address"].ToString(),
                        //    Fathers_Mobile_No = dr["Fathers_Mobile_No"].ToString(),
                        //    Mothers_Name = dr["Mothers_Name"].ToString(),
                        //   Mothers_Occupation = dr["Mothers_Occupation"].ToString(),
                        //   Name = dr["Name"].ToString(),
                        // ContentType = dr["ContentType"].ToString(),
                        //Data = dr["Data"].ToString(),






                    });

                }
                return obj;
            }
        }
    }
}

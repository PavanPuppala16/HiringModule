using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class Student
    {






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
                        Name_of_the_student= dr["Name_of_the_student"].ToString(),
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
        public static List<HiringSTD> GetData4()
        {
            List<HiringSTD> obj = new List<HiringSTD>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                //SqlDataAdapter da = new SqlDataAdapter("SP_HiringSTD1_Important1", con);
                SqlDataAdapter da = new SqlDataAdapter("select * from HiringSTD", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new HiringSTD
                    {
                        Sno = Convert.ToInt32(dr["Sno"].ToString()),
                        Hall_ticket_no= dr["Hall_ticket_no"].ToString(),
                        Name_of_the_student = dr["Name_of_the_student"].ToString(),
                        Emailid = dr["Emailid"].ToString(),
                        Dob = Convert.ToDateTime(dr["Dob"].ToString()),
                        // Gender = dr["Gender"].ToString(),
                        PH_No = Convert.ToInt64(dr["PH_No"].ToString()),
                        //Aadhar_no = Convert.ToInt32(dr["Aadhar_no"].ToString()),
                        //School_Name = dr["School_Name"].ToString(),
                        //ssc_Year_of_Pass_out = Convert.ToInt32(dr["ssc_Year_of_Pass_out"].ToString()),
                        Ssc_Aggregate =dr["Ssc_Aggregate"].ToString(),
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


        public static List<HTDD> GetData2()
        {
            List<HTDD> obj = new List<HTDD>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Displaydata_Project", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new HTDD
                    {
                        Sno = Convert.ToInt32(dr["Sno"].ToString()),

                        HallTicket = dr["HallTicket"].ToString(),
                        Name = dr["Name"].ToString(),
                        EmailID = dr["EmailID"].ToString(),
                        Dob = Convert.ToDateTime(dr["Dob"].ToString()),
                        Gender = dr["Gender"].ToString(),
                        StudentPHno = dr["StudentPHno"].ToString(),
                        SchoolName = dr["SchoolName"].ToString(),
                        SscPassYear = Convert.ToDateTime(dr["SscPassYear"].ToString()),
                        SscAggregate = Convert.ToInt32(dr["SscAggregate"].ToString()),
                        StudentAadhar = dr["StudentAadhar"].ToString(),
                        CollegeName = dr["CollegeName"].ToString(),
                        IntermediatePassYear = Convert.ToDateTime(dr["IntermediatePassYear"].ToString()),
                        IntermediateAggregate = Convert.ToInt32(dr["IntermediateAggregate"].ToString()),
                        EngineeringCollegeName = dr["EngineeringCollegeName"].ToString(),
                        Branch = dr["Branch"].ToString(),
                        EngineeringPassout = Convert.ToDateTime(dr["EngineeringPassout"].ToString()),
                        Backlog = Convert.ToInt32(dr["Backlog"].ToString()),
                        GraduationAggregate = Convert.ToInt32(dr["Backlog"].ToString()),

                        FathersName = dr["FathersName"].ToString(),
                        PermanentAddress = dr["PermanentAddress"].ToString(),
                        FathersMobileNo = dr["FathersMobileNo"].ToString(),
                        MothersName = dr["MothersName"].ToString(),

                        MothersOccupation = dr["MothersName"].ToString(),


                    });

                }
                return obj;
            }
        }



        public static List<HiringSTD> GetData3()
        {
            List<HiringSTD> obj = new List<HiringSTD>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_HiringSTD1_Important1", con);
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

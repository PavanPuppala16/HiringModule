using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;


namespace HiringOperation.Controllers
{
    public class BulkDataController : Controller
    {
        private IHostEnvironment Environment;
        private IConfiguration Configuration;
        public BulkDataController(IHostEnvironment _environment, IConfiguration _configuration)
        {
            Environment = _environment;
            Configuration = _configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //Create a Folder.
                string path = Path.Combine(this.Environment.ContentRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Save the uploaded Excel file.
                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                //Read the connection string for the Excel file.
                string conString = this.Configuration.GetConnectionString("ExcelConString");
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                //Insert the Data read from the Excel file to Database Table.
                conString = this.Configuration.GetConnectionString("constr");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.HiringSTD";

                        //[OPTIONAL]: Map the Excel columns with that of the database table.
                        //sqlBulkCopy.ColumnMappings.Add("Sno", "Sno");
                        sqlBulkCopy.ColumnMappings.Add("Hall_ticket_no", "Hall_ticket_no");
                        sqlBulkCopy.ColumnMappings.Add("Name_of_the_student", "Name_of_the_student");
                        sqlBulkCopy.ColumnMappings.Add("Emailid", "Emailid");
                        sqlBulkCopy.ColumnMappings.Add("Dob", "Dob");
                        sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                        sqlBulkCopy.ColumnMappings.Add("PH_No", "PH_No");
                        sqlBulkCopy.ColumnMappings.Add("Aadhar_no", "Aadhar_no");
                        sqlBulkCopy.ColumnMappings.Add("School_Name", "School_Name");
                        sqlBulkCopy.ColumnMappings.Add("ssc_Year_of_Pass_out", "ssc_Year_of_Pass_out");
                        sqlBulkCopy.ColumnMappings.Add("Ssc_Aggregate", "Ssc_Aggregate");
                        sqlBulkCopy.ColumnMappings.Add("Junior_College_Name", "Junior_College_Name");
                        sqlBulkCopy.ColumnMappings.Add("inter_Year_of_Pass_out", "inter_Year_of_Pass_out");
                        sqlBulkCopy.ColumnMappings.Add("inter_Aggregate", "inter_Aggregate");
                        sqlBulkCopy.ColumnMappings.Add("Engineering_College_Name", "Engineering_College_Name");
                        sqlBulkCopy.ColumnMappings.Add("Branch", "Branch");
                        sqlBulkCopy.ColumnMappings.Add("Btech_Year_of_Pass_out", "Btech_Year_of_Pass_out");
                        sqlBulkCopy.ColumnMappings.Add("Total_backlogs", "Total_backlogs");
                        sqlBulkCopy.ColumnMappings.Add("Graduation_Aggregate", "Graduation_Aggregate");
                        sqlBulkCopy.ColumnMappings.Add("Fathers_name", "Fathers_name");
                        sqlBulkCopy.ColumnMappings.Add("Fathers_occupation", "Fathers_occupation");
                        sqlBulkCopy.ColumnMappings.Add("Permanent_address", "Permanent_address");
                        sqlBulkCopy.ColumnMappings.Add("Present_address", "Present_address");
                        sqlBulkCopy.ColumnMappings.Add("Fathers_Mobile_No", "Fathers_Mobile_No");
                        sqlBulkCopy.ColumnMappings.Add("Mothers_Name", "Mothers_Name");
                        sqlBulkCopy.ColumnMappings.Add("Mothers_Occupation", "Mothers_Occupation");
                        sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        sqlBulkCopy.ColumnMappings.Add("ContentType", "ContentType");
                        sqlBulkCopy.ColumnMappings.Add("Data", "Data");
                        con.Open();

                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            return View();
        }

    }
}

using HiringOperation.Models;
using System.Data.SqlClient;
using System.Data;

namespace HiringOperation.Mainlogic
{
    public class EditDelete
    {

        public static Model1 GetDataByID(string RegisterId)
        {

            Model1 obj = null;
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_GETDATA_TBL_ADMIN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Model1();
                    obj.userid = Convert.ToInt32(ds.Tables[0].Rows[i]["userid"].ToString());
                    obj.RegisterId = ds.Tables[0].Rows[i]["RegisterId"].ToString();
                    obj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    obj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    obj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    obj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                    obj.Gender = ds.Tables[0].Rows[i]["Dob"].ToString();
                    obj.Dob = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                    obj.Role = ds.Tables[0].Rows[i]["Role"].ToString();
                    obj.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                }
                return obj;
            }
        }
        public static bool UpdateUsers(Model1 obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Update_UserData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@RegisterId", obj.RegisterId);
                    cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);

                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@Dob", Convert.ToDateTime(obj.Dob));
                    cmd.Parameters.AddWithValue("@Role", obj.Role);

                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@userid", obj.userid);
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
                    return res = true;
                }

        }
        public static bool UPDATEDATABYROLLNO(Model1 obj)
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
                    SqlCommand cmd = new SqlCommand("sp_Update_UserData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public static bool GetDataByROLLNO(String RegisterId)
        {
            bool res = false;
            Model1 OBJ = null;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_GETDATA_TBL_ADMIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        OBJ = new Model1();
                        OBJ.RegisterId = ds.Tables[0].Rows[i]["RegisterId"].ToString();
                        OBJ.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                        OBJ.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                        OBJ.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                        OBJ.Password = ds.Tables[0].Rows[i]["Password"].ToString();

                        OBJ.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                        OBJ.Dob = Convert.ToDateTime(ds.Tables[0].Rows[i]["Dob"].ToString());
                        OBJ.Role = ds.Tables[0].Rows[i]["Role"].ToString();
                        
                        OBJ.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                        OBJ.InsertionDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["InsertionDate"].ToString());
                        OBJ.userid = Convert.ToInt32(ds.Tables[0].Rows[i]["userid"].ToString());
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
        public static bool DELETEDataByROLLNO(String RegisterId)
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
                    SqlCommand cmd = new SqlCommand("sp_Delete_Users", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
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
                catch (Exception ex)
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

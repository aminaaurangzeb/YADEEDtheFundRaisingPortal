using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WebApplication6.Models
{
    public class CRUD
    {
        public static string connectionString = @"data source=RAIMA\SQLEXPRESS; Initial Catalog=fundme;Integrated Security=true";
        public static User ViewUser(string check)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                SqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                User U = new User();
                //U.email = rdr["email"].ToString();
                U.name = rdr["name"].ToString();
                U.phoneno = rdr["phoneno"].ToString();
                U.cnic = rdr["cnic"].ToString();



                rdr.Close();
                con.Close();
                return U;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;  //-1 will be interpreted as "error while connecting with the database."
            }

        }


        public static admin ViewAdmin(string check)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                SqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                admin A = new admin();

                A.email = rdr["email"].ToString();
                A.position = rdr["position"].ToString();
                A.cnic = rdr["cnic"].ToString();

                rdr.Close();
                con.Close();
                return A;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;  //-1 will be interpreted as "error while connecting with the database."
            }

        }

        public static int isAdmin(string Email)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("isAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;

                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int isUser(string Email)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("isUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;

                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<cases> getAllCases()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DisplayallCases", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<cases> list = new List<cases>();
                while (rdr.Read())
                {
                    cases C = new cases();

                    C.id = rdr.GetInt32(rdr.GetOrdinal("caseid"));
                    C.name = rdr["name"].ToString();
                    C.category = rdr["category"].ToString();
                    C.target = rdr.GetInt32(rdr.GetOrdinal("target_amount"));
                    C.link = rdr["linktocustomer"].ToString();

                    list.Add(C);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }
        public static List<User> getallUsers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("displayallUsers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<User> list = new List<User>();
                while (rdr.Read())
                {
                    User U = new User();
                    U.email = rdr["email"].ToString();
                   

                    list.Add(U);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }
        public static List<cases> getflaggedcases()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DisplayflaggedCases", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<cases> list = new List<cases>();
                while (rdr.Read())
                {
                    cases C = new cases();

                    C.id = rdr.GetInt32(rdr.GetOrdinal("caseid"));
                    C.name = rdr["name"].ToString();
                    C.category = rdr["category"].ToString();
                    C.target = rdr.GetInt32(rdr.GetOrdinal("target_amount"));
                    C.link = rdr["linktocustomer"].ToString();

                    list.Add(C);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }
        public static List<cases> gethealthCases()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("viewallHealthcases", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<cases> list = new List<cases>();
                while (rdr.Read())
                {
                    cases C = new cases();

                    C.id = rdr.GetInt32(rdr.GetOrdinal("caseid"));
                    C.name = rdr["name"].ToString();
                    C.category = rdr["category"].ToString();
                    C.target = rdr.GetInt32(rdr.GetOrdinal("target_amount"));
                    C.link = rdr["linktocustomer"].ToString();

                    list.Add(C);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<cases> geteduCases()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("viewallEducases", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<cases> list = new List<cases>();
                while (rdr.Read())
                {
                    cases C = new cases();

                    C.id = rdr.GetInt32(rdr.GetOrdinal("caseid"));
                    C.name = rdr["name"].ToString();
                    C.category = rdr["category"].ToString();
                    C.target = rdr.GetInt32(rdr.GetOrdinal("target_amount"));
                    C.link = rdr["linktocustomer"].ToString();

                    list.Add(C);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }


        public static List<myevent> getAllEvents()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DisplayallEvents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<myevent> list = new List<myevent>();
                while (rdr.Read())
                {
                    myevent E = new myevent();

                    E.eventid = rdr.GetInt32(rdr.GetOrdinal("eventid"));
                    E.name = rdr["name"].ToString();
                    E.category = rdr["category"].ToString();
                    E.date = rdr["eventDate"].ToString();
                    E.link = rdr["linktoeventpage"].ToString();

                    list.Add(E);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<myevent> getupcomingevent()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DisplayupcomingEvents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<myevent> list = new List<myevent>();
                while (rdr.Read())
                {
                    myevent E = new myevent();

                    E.eventid = rdr.GetInt32(rdr.GetOrdinal("eventid"));
                    E.name = rdr["name"].ToString();
                    E.category = rdr["category"].ToString();
                    E.date = rdr["eventDate"].ToString();
                    E.link = rdr["linktoeventpage"].ToString();

                    list.Add(E);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int signIn(string Email, string Password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("signIn", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int signUp(String name, String Email, String cnic, String Password, String dob, String gender, String phonenum)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("signUp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 13).Value = cnic;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;
                cmd.Parameters.Add("@dob", SqlDbType.VarChar, 20).Value = dob;
                cmd.Parameters.Add("@gender", SqlDbType.Char, 1).Value = gender;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 13).Value = phonenum;





                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int adminsignIn(string Email, string Password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            
            int result = 0;

            try
            {
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("adminsignin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@emailid", SqlDbType.VarChar, 30).Value = Email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);



                //cmd.ExecuteReader();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int adminSignUp(String email, String cnic, String Password, String Position)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("adminSignup", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;
                cmd.Parameters.Add("@position", SqlDbType.VarChar, 30).Value = Position;
                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 13).Value = cnic;
                
                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int addEvent(String check, int id, String name, String Category, String Date, String Link)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("addEvent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 20).Value = Category;
                cmd.Parameters.Add("@evedate", SqlDbType.VarChar, 20).Value = Date;
                cmd.Parameters.Add("@linktoeventpage", SqlDbType.VarChar, 20).Value = Link;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int addCase(String check, int id, String name, String Category, int target, String Link)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("addCase", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@caseid", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 20).Value = Category;
                cmd.Parameters.Add("@target_amount", SqlDbType.Int).Value = target;
                cmd.Parameters.Add("@linktocustomer", SqlDbType.VarChar, 20).Value = Link;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int removeCase(string check, int id)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("removeCase", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@caseid", SqlDbType.Int).Value = id;

                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }


        public static int removeEvent(string check, int id)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("removeEvent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = id;

                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int deleteuser(string check, String useremail)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("deleteUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@useremail", SqlDbType.VarChar, 30).Value = useremail;

                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }


        public static int reportcase(string check, String name)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("reportCase", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int requestVisit(string check, String name)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("requestvisit", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;


                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }


        public static int Registerasdonor(String check, String accno, String visitingadd)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("registerAsDonor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@accountno", SqlDbType.VarChar, 20).Value = accno;
                cmd.Parameters.Add("@visitingaddress", SqlDbType.VarChar, 50).Value = visitingadd;
                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }


        public static List<myevent> eventhistory(String check)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("volunteer_history", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                SqlDataReader rdr = cmd.ExecuteReader();
                List<myevent> d = new List<myevent>();
                while (rdr.Read())
                {

                    myevent temp = new myevent();

                    temp.eventid = rdr.GetInt32(rdr.GetOrdinal("eventid"));
                    temp.name = rdr["name"].ToString();
                    temp.date = rdr["eventDate"].ToString();
                    temp.category = rdr["category"].ToString();
                    
                    temp.link = rdr["linktoeventpage"].ToString();
                    d.Add(temp);
                }
                rdr.Close();
                con.Close();
                return d;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        public static List<donations> donationshistory(String check)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("donation_history", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                SqlDataReader rdr = cmd.ExecuteReader();
                List<donations> d = new List<donations>();
                while (rdr.Read())
                {

                    donations temp = new donations();
                    temp.caseid = rdr.GetInt32(rdr.GetOrdinal("caseid"));
                    temp.amount_donated = rdr.GetInt32(rdr.GetOrdinal("amount_donated"));
                    d.Add(temp);
                }
                rdr.Close();
                con.Close();
                return d;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }

        }


        public static int Registerasvolunteer(String check, String eventname, String position)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("registerAsVolunteer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@eventname", SqlDbType.VarChar, 20).Value = eventname;
                cmd.Parameters.Add("@position", SqlDbType.VarChar, 30).Value = position;
                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int donate(String check, String casename, int amount)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("Donate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = check;
                cmd.Parameters.Add("@casename", SqlDbType.VarChar, 20).Value = casename;
                cmd.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
                cmd.Parameters.Add("@done", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@done"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
    }

}
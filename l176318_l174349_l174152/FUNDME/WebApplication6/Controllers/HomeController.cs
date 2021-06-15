using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


using System.Web;

using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult homePage()
        {
            return View();
        }
        public ActionResult signin()
        {
            return View();
        }
        public ActionResult AdminSignin()
        {
            return View();

        }
        public ActionResult signup()
        {
            return View();

        }
       
        public ActionResult UserAccount()
        {  
            if (Session["email"] == null)
                return RedirectToAction("homePage");
            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                User users = CRUD.ViewUser(check);
                Console.Write(users);
                return View(users);
            }
        }

        public ActionResult AdminAccount()
        {            
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                admin Admin = CRUD.ViewAdmin(check);
                Console.Write(Admin);
                return View(Admin);
            }
        }

        public ActionResult addEvent()
        {
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            String check = Session["email"].ToString();

            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                admin Admin = CRUD.ViewAdmin(check);
                Console.Write(Admin);
                return View(Admin);
            }
        }
        public ActionResult addCase()
        {
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                admin Admin = CRUD.ViewAdmin(check);
                Console.Write(Admin);
                return View(Admin);
            }
        }

        public ActionResult removeCase()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("homePage");
            }
            string check = Session["email"].ToString();
            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.getAllCases();
                if (C == null)
                {
                    RedirectToAction("AdminAccount");
                }

                Console.Write(C);
                return View(C);
            }
        }
        public ActionResult removeflaggedCase()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("homePage");
            }
            string check = Session["email"].ToString();
            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.getflaggedcases();
                if (C == null)
                {
                    RedirectToAction("AdminAccount");
                }

                Console.Write(C);
                return View(C);
            }
        }

        public ActionResult removeEvent()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("homePage");
            }

            string check = Session["email"].ToString();
            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                List<myevent> E = CRUD.getAllEvents();
                if (E == null)
                {
                    RedirectToAction("AdminAccount");
                }
                Console.Write(E);
                return View(E);
            }
        }

        public ActionResult deleteUser()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("homePage");
            }

            string check = Session["email"].ToString();
            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                List<User> U = CRUD.getallUsers();
                if (U == null)
                {
                    RedirectToAction("AdminAccount");
                }
                Console.Write(U);
                return View(U);
            }
        }

        public ActionResult adminSignup()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("homePage");
            }

            string check = Session["email"].ToString();
            int isadmin = CRUD.isAdmin(check);
            if (isadmin != 1) //if not admin
                return RedirectToAction("homePage");
            else
            {
                return View();
            }
        }
        public ActionResult info()
        {
            
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                User user = CRUD.ViewUser(check);
                Console.Write(user);
                return View(user);
            }
        }
        public ActionResult viewHealth()
        {

            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.gethealthCases();
                Console.Write(C);
                return View(C);
            }
        }

        public ActionResult viewedu()
        {

            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.geteduCases();
                Console.Write(C);
                return View(C);
            }
        }
        public ActionResult upcomingEvent()
        {

            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<myevent> E = CRUD.getupcomingevent();
                Console.Write(E);
                return View(E);
            }
        }

        public ActionResult reportCase()
        {
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.getAllCases();
                Console.Write(C);
                return View(C);
            }
        }
        public ActionResult requestVisit()
        {
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<myevent> E= CRUD.getAllEvents();
                Console.Write(E);
                return View(E);
            }
        }
        public ActionResult registerasdonor()
        {
            
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                User user = CRUD.ViewUser(check);
                Console.Write(user);
                return View(user);
            }
        }
        public ActionResult volunteer()
        {
            
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();
            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<myevent> E = CRUD.getAllEvents();
                Console.Write(E);
                return View(E);
            }
        }
        public ActionResult donate()
        {
            if (Session["email"] == null)
                return RedirectToAction("homePage");
            //User user = CRUD.ViewUser(check);

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<cases> C = CRUD.getAllCases();
                Console.Write(C);
                return View(C);
            }
        }
        public ActionResult donationHistory()
        {
           
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();

            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<donations> dons = CRUD.donationshistory(check);
                Console.Write(dons);
                return View(dons);
            }
        }

        public ActionResult volunteerHistory()
        {
            
            if (Session["email"] == null)
                return RedirectToAction("homePage");

            string check = Session["email"].ToString();
            int isuser = CRUD.isUser(check);
            if (isuser != 1) //if not user
                return RedirectToAction("homePage");
            else
            {
                List<myevent> dons = CRUD.eventhistory(check);
                Console.Write(dons);
                return View(dons);
            }
        }
        public ActionResult authenticate(String email, String password)
        {
            int result = CRUD.signIn(email, password);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("signin", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("signin", (object)data);
            }
            Session["email"]=email;
  

            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate1(String name, String Email, String cnic, String Password, String dob, String gender, String phonenum)
        {

            int result = CRUD.signUp(name, Email, cnic, Password, dob, gender, phonenum);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("signup", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("signup", (object)data);
            }
            Session["email"] = Email;
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate2(String email, String password) //admin sign in 
        {
            int result = CRUD.adminsignIn(email, password);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("AdminSignin", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("AdminSignin", (object)data);
            }

            Session["email"] = email;

            string check = Session["email"].ToString();

            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate3(int id, String name, String Category, String Date, String Link) //admin add event
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.addEvent(check, id, name, Category, Date, Link);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("addEvent", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("addEvent", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate4(int id, String name, String Category, int target, String Link) //admin add case
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.addCase(check, id, name, Category,target, Link);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("addCase", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("addCase", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate5() //returntouser
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate6(String id) //remove case
        {
            String check = Session["email"].ToString();
            int id1 = Convert.ToInt32(id);
            int result = CRUD.removeCase(check, id1);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("removeCase", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("removeCase", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate7(String id) //remove event
        {
            String check = Session["email"].ToString();

            int id1 = Convert.ToInt32(id);
            int result = CRUD.removeEvent(check, id1);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("removeEvent", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("removeEvent", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }

        public ActionResult authenticate8() //admin logout//user
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            Session["email"] = null;
            return RedirectToAction("homePage");

        }
        public ActionResult authenticate9(String accno, String visitingadd) //registerasdonor
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.Registerasdonor(check, accno, visitingadd);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("registerasdonor", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("registerasdonor", (object)data);
            }
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate10(String eventname, String position) //registerasvolunteer
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.Registerasvolunteer(check, eventname, position);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return RedirectToAction("volunteer");
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return RedirectToAction("volunteer");
            }
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate11(String casename, int amount) //donate
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.donate(check, casename, amount);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return RedirectToAction("donate");
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return RedirectToAction("donate");
            }
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate12() //returntoadmin
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");


            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate13(String name ) //report case
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.reportcase(check, name);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return RedirectToAction("reportCase");
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return RedirectToAction("reportCase");
            }
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate14(String name) //request visit
        {
            String check = Session["email"].ToString();

            if (check == null)
                return RedirectToAction("homePage");

            int result = CRUD.requestVisit(check, name);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return RedirectToAction("requestVisit");
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return RedirectToAction("requestVisit");
            }
            return RedirectToAction("UserAccount");

        }
        public ActionResult authenticate15(String id) //remove flagged case
        {
            String check = Session["email"].ToString();
            int id1 = Convert.ToInt32(id);
            int result = CRUD.removeCase(check, id1);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("removeflaggedCase", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("removeflaggedCase", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }

        public ActionResult authenticate16(String email) //remove user
        {
            String check = Session["email"].ToString();
            int result = CRUD.deleteuser(check, email);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("deleteUser", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("deleteUser", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }
        public ActionResult authenticate17(String email, String cnic, String Password, String Position) //admin sign up
        {
            String check = Session["email"].ToString();
            int result = CRUD.adminSignUp(email, cnic, Password, Position);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("adminSignup", (object)data);
            }
            else if (result == 0)
            {
                String data = "Incorrect Credentials";
                return View("adminSignup", (object)data);
            }
            return RedirectToAction("AdminAccount");

        }

    }
}


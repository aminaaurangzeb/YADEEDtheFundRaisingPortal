using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class User
    {
        public string email;
        public string password;
        public string name;
        public string dob;
        public string gender;
        public string phoneno;
        public string cnic;
    }
    public class donor
    {
        public string email;
        public string accountno;
        public string visitingadd;
        public string medal;
        public int caseid;
        public int amount;
    }
    public class volunteer
    {
        public string email;
        public int eventid;
        public string position;
    }
    public class admin
    {
        public string email;
        public string password;
        public string cnic;
        public string position;
    }
    public class cases
    {
        public int id;
        public string name;
        public string category;
        public int target;
        public int collected_amount;
        public string link;
    }

    public class donations
    {
        public int caseid;
        public int amount_donated;
    }


    public class myevent
    {
        public int eventid;
        public string name;
        public string date;
        public string category;
        public string link;
    }

}
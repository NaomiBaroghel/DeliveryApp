//using DemoDataProtocol;
using BE;
using BL;
using System;
using System.Collections.Generic;
using WPFHalonotTrue.View;
using WPFHalonotTrue.ViewModels;

namespace WPFHalonotTrue.Models
{
    public class LoginModel
    {
        public string password { get; set; }
        public BLImp blimp { get; set; }

        public LoginModel(LoginVM myvm)
        {
            blimp = new BLImp();
            password = "mypassword";
        }

        //check if the password given is like the password choosen
        public bool CheckPassword(string givenpassword)
        {
            if (givenpassword == password )
                return true;
            return false;
        }

        //create the database if not already create
        public void createSQL()
        {
            try
            {
                Configuration config = new Configuration();
                blimp.AddConfig(config);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}

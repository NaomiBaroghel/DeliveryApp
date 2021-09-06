//using DemoDataProtocol;
using BE;
using BL;
//using BL;
using System;
using System.Collections.Generic;


namespace WPFHalonotTrue.Models
{
    public class EmployeeModel
    {
        BLImp blimp { get; set; }
        public EmployeeModel()
        {
            blimp = new BLImp();
            
        }

        //addDMan to the list
        public void AddDMan(DeliveryMan mydman)
        {
            try
            {
                blimp.AddDMan(mydman);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


       

        
    }
}

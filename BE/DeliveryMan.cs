using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DeliveryMan
    {
        private int idDMan;
        public int IDDMan
        {
            get { return idDMan; }
            set { idDMan = value; }
        }
        private String firstname;
        public String FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private String lastname;
        public String LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private String mail;
        public String Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        private String phone;
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private List<Distribution> alldistributions;
        public List<Distribution> AllDistributions
        {
            get { return alldistributions; }
            set { alldistributions = value; }
        }

    }
}

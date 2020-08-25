using System;

namespace BE
{
    public class Client
    {
        private int idClient;
        public int IDClient
        {
            get { return idClient; }
            set { idClient = value; }
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
        private Address myaddress;
        public Address MyAddress
        {
            get { return myaddress; }
            set { myaddress = value; }
        }
        private Boolean food;
        public Boolean Food
        {
            get { return food; }
            set { food = value; }
        }
        private Boolean drug;
        public Boolean Drug 
        {
            get { return drug; }
            set { drug = value; }
        }

        private Boolean assignsF; 
        public Boolean AssignsF //est ce qu'il y a une distribution lorsque food == true
        {
            get { return assignsF; }
            set { assignsF = value; }
        }

        private Boolean assignsD;
        public Boolean AssignsD // est ce qu'il y a une distribution lorsque drug == true
        {
            get { return assignsD; }
            set { assignsD = value; }
        }

        public Client()
        {
            Food = false;
            Drug = false;
            AssignsF = false;
            AssignsD = false;
        }


    }
}

using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Table("DMan")]

    public class DeliveryMan
    {
       
        private int idDMan;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDMan { get; set; }
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

        private ICollection<Distribution> alldistributions;
        public virtual ICollection<Distribution> AllDistributions
        {
            get { return alldistributions; }
            set { alldistributions = value; }
        }

        public DeliveryMan()
        {
            AllDistributions = new List<Distribution>();
        }

        public DeliveryMan(string firstName, string lastName, string mail, string phone)
        {
            AllDistributions = new List<Distribution>();

            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Phone = phone;
        }
    }
    }

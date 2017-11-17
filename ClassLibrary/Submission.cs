using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

 
namespace ClassLibrary
{
    
    public class Submission
    {
        private string firstName, lastName, email, phone, birthday, serialNumber;

        public Submission()
        {

        }

        public Submission(string firstName, string lastName, string email, string phone, string birthday, string serialNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.birthday = birthday;
            this.serialNumber = serialNumber;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
    }
}

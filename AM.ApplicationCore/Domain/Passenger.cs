using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public String PasseportNumber { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public String EmailAdresse { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile(String firstName, String lastName)
        {
            return FirstName.Equals(firstName) && LastName.Equals(lastName);
        }
        public bool CheckProfile(String firstName, String lastName, String email)
        {
            //return FirstName.Equals(firstName) && LastName.Equals(lastName) && EmailAdresse.Equals(email);
            return CheckProfile(firstName, lastName, email) && EmailAdresse.Equals(email); //polymorphisme par signature
        }

        public bool Login(String firstName, String lastName, String email = null)
        {
            if (email != null)
                return CheckProfile(firstName, lastName, email );
            return CheckProfile(firstName,lastName);
            
        }

<<<<<<< HEAD
        public virtual void PassengerTye()
        {
            Console.WriteLine("Im passenger");
        }

=======
>>>>>>> f61595b68a5a8e23bc93ad2b5d78efe365441702

    }
}

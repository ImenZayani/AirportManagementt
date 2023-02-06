using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Key, StringLength(7)]
        public String PasseportNumber { get; set; }
        public FullName FullName { get; set; }

        [DataType(DataType.Date), Display(Name ="Date of birthday")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        //[Range(0, 8)] //ou [DataType(DataType.PhoneNumber)]
        public int TelNumber { get; set; }

        [EmailAddress]  //or [DataType(DataType.EmailAddress)]  
        public String EmailAdresse { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile(String firstName, String lastName)
        {
            return FullName.FirstName.Equals(firstName) && FullName.LastName.Equals(lastName);
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

        public virtual void PassengerTye()
        {
            Console.WriteLine("Im passenger");
        }

    }
}

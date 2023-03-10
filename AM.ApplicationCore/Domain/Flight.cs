using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public String Departure { get; set; }
        public String Destination { get; set; }

        public string Airline { get; set; }
      
        public int PlaneFK { get; set; }
        [ForeignKey("PlaneFK")]   // on l'a fait par la configuration dans flightconfiguration:
                                  //les deux méthodes sont valides

        public Plane Plane { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
        public ICollection<Traveller> Travellers { get; set; }



        public Flight()
        {

        }

    }
}

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public IList<Flight> Flights { get; set; }
        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates=new List<DateTime>();
            //------------------ FOR -----------------------------------
            //for (int i=0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination.Equals(destination))
            //   {
            //   dates.Add(Flights[i].FlightDate);
            //   }
            // }
            //-------------------- FOREACH ---------------------------------
            //foreach(Flight item in Flights)
            //{
            //     if (item.Destination.Equals(destination))
            //    {
            //        dates.Add(item.FlightDate);
            //    }
            //}
            //    return dates;

            //--------------------- QUERY --------------------------------

            var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            return query.ToList();
            
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights
                        where f.Plane == plane
                        select (f.FlightDate, f.Destination);
        }
    }
}

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public IList<Flight> Flights { get; set; }
        public IList<Traveller> Travellers { get; set; }

        public double DurationAverage(string destination)
        {
            //return Flights.Where(f => f.Destination.Equals(destination)).Select(f=>f.EstimatedDuration).Average();
            //ou
            return Flights.Where(f => f.Destination.Equals(destination)).Average(f => f.EstimatedDuration);
        }

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

        public IEnumerable<Flight> OrderedDurationFlights()
        {
           // return Flights.OrderByDescending(f => f.EstimatedDuration);
           //or query
           var query = from f in Flights
                       orderby f.EstimatedDuration descending
                       select f;
            return query;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //return Flights.Where(f=>(f.FlightDate - startDate).TotalDays < 7).Select(f=>f.FlightDate).Count();
            return Flights.Where(f => (f.FlightDate - startDate).TotalDays < 7).Count();
            //var query = from f in Flights
            //            where (f.FlightDate - startDate).TotalDays < 7
            //            select f;
            //return query.Count();
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //return flight.Passengers.OfType<Traveller>().OrderBy(f=>f.BirthDate).Take(3);
            //or
            var query = from f in flight.Passengers.OfType<Traveller>()
                        orderby f.BirthDate
                        select f;
            return query.Take(3);
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane == plane
            //            //select (f.FlightDate, f.Destination);
            //            select new { f.FlightDate, f.Destination };
            var lambda = Flights.Where(f=>f.Plane==plane).Select(f=>new { f.FlightDate, f.Destination });
            foreach(var f in lambda) {   //query
                {
                    Console.WriteLine(f.FlightDate + " " + f.Destination);
                } }

        }
    }
}

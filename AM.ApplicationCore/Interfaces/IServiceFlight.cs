using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        IList<DateTime> GetFlightDates(string destination);
        void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);

        Double DurationAverage(string destination);

        IEnumerable<Flight> OrderedDurationFlights();

        IEnumerable<Traveller> SeniorTravellers(Flight flight);

        IEnumerable<IGrouping<String, Flight>> DestinationGroupedFlights();
    }
}

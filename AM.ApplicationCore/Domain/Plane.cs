using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {

        //   public string Name;
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public planeType PlanType { get; set; }

    }
}

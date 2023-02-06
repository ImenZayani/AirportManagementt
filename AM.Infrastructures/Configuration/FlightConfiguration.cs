using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructures.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(p => p.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(a => a.ToTable("Voyageeurs"));

            builder.HasOne(f => f.Plane)
                .WithMany(f => f.Flights)
                .OnDelete(DeleteBehavior.Cascade); //activation delete en cascade
                //.HasForeignKey(p => p.PlaneFK); //ou annotation
        }
    }
}

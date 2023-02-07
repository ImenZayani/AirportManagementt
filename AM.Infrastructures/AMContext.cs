using AM.ApplicationCore.Domain;
using AM.Infrastructures.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructures
{
    public class AMContext:DbContext
    {
        public  DbSet<Plane> Planes { get; set; }
        public  DbSet<Flight> Flights { get; set; }
        public  DbSet<Passenger> Passengers { get; set; }
        public  DbSet<Staff> Staff { get; set; }
        public  DbSet<Traveller> Travellers { get; set; }

        //chaine de connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=AirportManagement;
            Integrated Security=true;MultipleActiveResultSets=true");
        }

        //class de configu definies avec fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            //Has  un  Type  Complex 
            modelBuilder.Entity<Passenger>()

                .OwnsOne(p => p.FullName, full =>
            {
                full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });//configuration de  TPH
                 //.HasDiscriminator<int>("PassengerType")
                 //.HasValue<Passenger>(0)
                 //.HasValue<Traveller>(1)
                 //.HasValue<Staff>(2);


            //Configuration de TPT 

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


            //2eme methode de configuration
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, full =>
            {
                full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}

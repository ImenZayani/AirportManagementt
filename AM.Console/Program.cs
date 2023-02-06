// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
//Plane p1 = new Plane(100, new DateTime(12/12/2022),1);
//Plane p2 = new Plane
//{
//    Capacity = 100,
//    ManufactureDate = new DateTime(12 - 12 - 2022),
//    PlaneId = 1000,
   

//};

Passenger p1 = new Passenger
{
    FullName = new FullName
    {
        FirstName = "Test",
        LastName = "Test",
    },
    
    EmailAdresse = "test.test@gmail.com",
};

Staff s1 = new Staff
{
    FullName = new FullName
    {
        FirstName = "staff",
        LastName = "staff"
    },
    
    EmailAdresse = "staff.staff@gmail.com",
};

Traveller t1 = new Traveller
{
    FullName = new FullName {
        FirstName = "Traveller",
        LastName = "Traveller"
    },
    
    EmailAdresse = "traveller.traveller@gmail.com"
};


Console.WriteLine(p1.CheckProfile("Test", "Test"));
Console.WriteLine(p1.CheckProfile("Test", "Test", "test.test@gmail.com"));


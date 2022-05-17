using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMathHelpers _mathHelpers;

        public DataInitializer(ApplicationDbContext context, IMathHelpers mathHelpers)
        {
            _context = context;
            _mathHelpers = mathHelpers;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedCustomers();
            SeedProjects();
            SeedTimeReports();
        }

        public void SeedCustomers()
        {
            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(new Customer
                {
                    Name = "Jannes Stålrör och brännbollsträn",
                    
                });
                _context.Customers.Add(new Customer
                {
                    Name = "Lågt hängande frukt HB",

                });
                _context.Customers.Add(new Customer
                {
                    Name = "Åka snabbt elscooter-riksha AB",

                });

            }

            _context.SaveChanges();
        }

        public void SeedProjects()
        {
            if (_context.Projects.Count() == 0)
            {
                _context.Projects.Add(new Project
                {
                    Name = "Webshop 1.5",
                    CostPerHour = 2000,
                    CustomerId = 1,
                    Description = "Halvny webshop, mest gammalt men lite nytt",

                });
                _context.Projects.Add(new Project
                {
                    Name = "Faktureringssystem",
                    CostPerHour = 3000,
                    CustomerId = 2,
                    Description = "Nytt faktureringssystem i .NET",

                });
                _context.Projects.Add(new Project
                {
                    Name = "Logotyp",
                    CostPerHour = 1300,
                    CustomerId = 3,
                    Description = "Ny logotyp gjord i enbart ASCII",

                });
                _context.Projects.Add(new Project
                {
                    Name = "Webgränssnitt för att komma åt API",
                    CostPerHour = 4200,
                    CustomerId = 1,
                    Description = "Gränssnitt i JS för att läsa in API med branschnyheter",

                });
                _context.Projects.Add(new Project
                {
                    Name = "Inloggning till intranät",
                    CostPerHour = 700,
                    CustomerId = 2,
                    Description = "Kund önskar inloggningssystem för att komma åt intranät",

                });

            }

            _context.SaveChanges();
        }

        public void SeedTimeReports()
        {
            if (_context.TimeReports.Count() == 0)
            {
                _context.TimeReports.Add(new TimeReport
                {
                   NoHours = 4,
                   Date = DateTime.Today.AddDays(-10),
                   ProjectId = 1,
                   Sum = _mathHelpers.HoursSum(4, _context.Projects.FirstOrDefault(e=>e.Id == 1).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 8,
                    Date = DateTime.Today.AddDays(-1),
                    ProjectId = 2,
                    Sum = _mathHelpers.HoursSum(8, _context.Projects.FirstOrDefault(e => e.Id == 2).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 10,
                    Date = DateTime.Today.AddDays(-45),
                    ProjectId = 3,
                    Sum = _mathHelpers.HoursSum(10, _context.Projects.FirstOrDefault(e => e.Id == 3).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 1,
                    Date = DateTime.Today.AddDays(-33),
                    ProjectId = 4,
                    Sum = _mathHelpers.HoursSum(1, _context.Projects.FirstOrDefault(e => e.Id == 4).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 5,
                    Date = DateTime.Today.AddDays(-1),
                    ProjectId = 5,
                    Sum = _mathHelpers.HoursSum(5, _context.Projects.FirstOrDefault(e => e.Id == 5).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 4,
                    Date = DateTime.Today.AddDays(-5),
                    ProjectId = 1,
                    Sum = _mathHelpers.HoursSum(4, _context.Projects.FirstOrDefault(e => e.Id == 1).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 2,
                    Date = DateTime.Today.AddDays(-15),
                    ProjectId = 1,
                    Sum = _mathHelpers.HoursSum(2, _context.Projects.FirstOrDefault(e => e.Id == 2).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 8,
                    Date = DateTime.Today.AddDays(-14),
                    ProjectId = 2,
                    Sum = _mathHelpers.HoursSum(8, _context.Projects.FirstOrDefault(e => e.Id == 3).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 16,
                    Date = DateTime.Today.AddDays(-28),
                    ProjectId = 3,
                    Sum = _mathHelpers.HoursSum(16, _context.Projects.FirstOrDefault(e => e.Id == 4).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 2,
                    Date = DateTime.Today.AddDays(-4),
                    ProjectId = 4,
                    Sum = _mathHelpers.HoursSum(2, _context.Projects.FirstOrDefault(e => e.Id == 5).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 3,
                    Date = DateTime.Today.AddDays(-8),
                    ProjectId = 5,
                    Sum = _mathHelpers.HoursSum(3, _context.Projects.FirstOrDefault(e => e.Id == 1).CostPerHour)

                });
                _context.TimeReports.Add(new TimeReport
                {
                    NoHours = 9,
                    Date = DateTime.Today.AddDays(-6),
                    ProjectId = 1,
                    Sum = _mathHelpers.HoursSum(9, _context.Projects.FirstOrDefault(e => e.Id == 2).CostPerHour)

                });

            }

            _context.SaveChanges();
        }
    }
}

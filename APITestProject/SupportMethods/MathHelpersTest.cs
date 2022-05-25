using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.SupportMethods;
using static TimeRegisterAPI.SupportMethods.MathHelpers;

namespace APITestProject.SupportMethods
{
    [TestClass]
    public class MathHelpersTest
    {
        private MathHelpers _sut;
        private ApplicationDbContext _context;
        public MathHelpersTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _sut = new MathHelpers(_context);
        }

        [TestMethod]
        public void Time_Spent_So_Far_Calculates_Correctly()
        {
            CreateCustomer();
            CreateProject();
            CreateTimeReport();
            CreateTimeReport();
            CreateTimeReport();
            var result = _sut.TimeSpentSoFar(_context.Projects.FirstOrDefault(x => x.Id == 1));
            Assert.AreEqual(12, result);
        }


        public void CreateCustomer()
        {
            _context.Customers.Add(new Customer
            {
                Name = "Test Kund",
            });
        }

        public void CreateProject()
        {
            _context.Projects.Add(new Project
            {
                Name = "Test Projekt",
                PricePerHour = 1000,
                CustomerId = 1,
                Active = true,
                Description = "Projekt för testning",
                EndDate = DateTime.Today.AddDays(30)
            });
           
        }

        public void CreateTimeReport()
        {
            _context.TimeReports.Add(new TimeReport
            {
                Description = "Test Tidsrapport",
                NoHours = 4,
                Date = DateTime.Today.AddDays(-10),
                ProjectId = 1,
                Processed = false,
                CustomerId = 1,
                Sum = 0
            });
        }

        
        

    }
}

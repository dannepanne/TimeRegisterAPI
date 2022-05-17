using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;
using TimeRegisterAPI.DTO.ProjDTO;

namespace TimeRegisterAPI.SupportMethods
{
    public class DbObjectMethods :IDbObjectMethods
    {
        private readonly ApplicationDbContext _context;

        public DbObjectMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UpdateCustomer(int id, UpdateCustomerDTO thiscust)
        {
            var cust = _context.Customers.FirstOrDefault(t => t.Id == id);
            if (cust == null) 
                return false;
            cust.Name = thiscust.Name;
            _context.SaveChanges();
            return true;
        }

        public void SaveNewCustomer(Customer cust)
        {
            _context.Customers.Add(cust);
            _context.SaveChanges();
        }

        public bool UpdateProject(int id, UpdateProjectDTO thisproj)
        {
            var proj = _context.Projects.FirstOrDefault(t => t.Id == id);
            if (proj == null)
                return false;
            proj.Name = thisproj.Name;
            proj.Description = thisproj.Description;
            proj.PricePerHour = thisproj.PricePerHour;
            _context.SaveChanges();
            return true;
        }

        public void SaveNewProject(Project proj)
        {
            _context.Projects.Add(proj);
            _context.SaveChanges();
        }

    }
}

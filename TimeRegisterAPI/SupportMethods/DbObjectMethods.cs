using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;

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


    }
}

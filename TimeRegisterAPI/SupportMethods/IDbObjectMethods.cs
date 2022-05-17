using TimeRegisterAPI.Data;
using TimeRegisterAPI.DTO;
using TimeRegisterAPI.DTO.CustDTO;

namespace TimeRegisterAPI.SupportMethods
{
    public interface IDbObjectMethods
    {
        public bool UpdateCustomer(int id, UpdateCustomerDTO thiscust);
        public void SaveNewCustomer(Customer cust);


    }
}
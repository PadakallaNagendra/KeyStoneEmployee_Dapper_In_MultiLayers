using KeyStoneEmployeeManageMent_BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_BusinessObject.InterFace
{
    public interface ICustomerRepositary
    {
        public Task<List<Customer>> GetAllCustomer();
        public Task<Customer> GetCustomerById(int id);
        public Task<bool> AddCustomer(Customer customer);
        public Task<bool> DeleteCustomer(int id);

        public Task<bool> UpdateCustomer(Customer customer);
    }
}

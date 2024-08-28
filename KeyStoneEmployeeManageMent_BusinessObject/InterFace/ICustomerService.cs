using KeyStoneEmployeeManageMent_BusinessObject.Entities;
using KeyStoneEmployeeManageMent_BusinessObject.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_BusinessObject.InterFace
{
    public interface ICustomerService
    {
        public Task<List<CustomerDTO>> GetAllCustomer();
        public Task<CustomerDTO> GetCustomerById(int id);
        public Task<bool> AddCustomer(CustomerDTO customerDto);
        public Task<bool> DeleteCustomer(int id);

        public Task<bool> UpdateCustomer(CustomerDTO customerDto);
    }
}

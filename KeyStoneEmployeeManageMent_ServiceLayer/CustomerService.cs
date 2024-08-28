using KeyStoneEmployeeManageMent_BusinessObject.Entities;
using KeyStoneEmployeeManageMent_BusinessObject.InterFace;
using KeyStoneEmployeeManageMent_BusinessObject.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_ServiceLayer
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepositary _customerRepositary;
        public CustomerService(ICustomerRepositary customerRepositary)
        {
            _customerRepositary = customerRepositary;
        }

        public async Task<bool> AddCustomer(CustomerDTO customerDto)
        {
            Customer obj = new Customer();
           // obj.id = customerDto.id;
            obj.Customername=customerDto.Customername;
            obj.country = customerDto.country;
            obj.Email = customerDto.Email;
            obj.city = customerDto.city;
            await _customerRepositary.AddCustomer(obj);
            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
           await _customerRepositary.DeleteCustomer(id);
            return true;
        }

        public async Task<List<CustomerDTO>> GetAllCustomer()
        {
           List<CustomerDTO> list = new List<CustomerDTO>();
            var res=await _customerRepositary.GetAllCustomer();
            foreach(Customer customer in res)
            {
                CustomerDTO dto = new CustomerDTO();
                dto.id = customer.id;
                dto.Customername = customer.Customername;
                dto.country = customer.country;
                dto.city = customer.city;
                dto.Email = customer.Email;
                list.Add(dto);
            }
            return list;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var result = await _customerRepositary.GetCustomerById(id);

            CustomerDTO htldto = new CustomerDTO();
            htldto.id = result.id;
            htldto.Customername = result.Customername;
            htldto.country = result.country;
            htldto.Email= result.Email;
            htldto.city = result.city;
           

            return htldto;
        }

        public async Task<bool> UpdateCustomer(CustomerDTO customerDto)
        {
           Customer customer = new Customer();
            customer.id = customerDto.id;
            customer.Customername = customerDto.Customername;
            customer.country = customerDto.country;
            customer.city = customerDto.city;
            customer.Email= customerDto.Email;
            await _customerRepositary.UpdateCustomer(customer);
            return true;
        }
    }
}

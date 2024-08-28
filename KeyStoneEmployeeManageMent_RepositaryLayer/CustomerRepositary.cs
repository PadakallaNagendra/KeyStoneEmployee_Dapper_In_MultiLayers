using Dapper;
using KeyStoneEmployeeManageMent_BusinessObject.Entities;
using KeyStoneEmployeeManageMent_BusinessObject.InterFace;
using KeyStoneEmployeeManageMent_DataBaseLogic.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_RepositaryLayer
{
    public class CustomerRepositary : ICustomerRepositary
    {
        public IConfigurationFactory _ConfigurationFactory;
        public CustomerRepositary(IConfigurationFactory configurationFactory)
        {
            _ConfigurationFactory = configurationFactory;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            using(IDbConnection con = _ConfigurationFactory.Connection())
            {
                var p = new  DynamicParameters();
              //  p.Add("@id", customer.id);
                p.Add("@CustomerName", customer.Customername);
                p.Add("@Email", customer.Email);
                p.Add("@Country", customer.country);
                p.Add("@City",customer.city);
                await con.ExecuteScalarAsync<Customer>(StoreProcedureStatusMessages.AddCustomer, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            using(IDbConnection con = _ConfigurationFactory.Connection())
            {
                var p = new DynamicParameters();
                p.Add("@id", id);
                await con.ExecuteScalarAsync(StoreProcedureStatusMessages.DeleteCustomer,p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> res = new List<Customer>();
            using(IDbConnection con=_ConfigurationFactory.Connection())
            {
                var result=await con.QueryAsync<Customer>(StoreProcedureStatusMessages.GetAllCustomer, commandType: CommandType.StoredProcedure);
                var status = result.ToList();
                return status;
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer obj = new Customer();
            using(IDbConnection con = _ConfigurationFactory.Connection())
            {
                var p=new DynamicParameters();
                p.Add("@id", id);
                var res=await con.QueryAsync<Customer>(StoreProcedureStatusMessages.GetByIdCustomer, p, commandType: CommandType.StoredProcedure);
                var resulte = res.FirstOrDefault();
                return resulte;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
           using(IDbConnection con = _ConfigurationFactory.Connection())
            {
                var p=new DynamicParameters();
                p.Add("@id", customer.id);
                p.Add("@CustomerName", customer.Customername);
                p.Add("@Email", customer.Email);
                p.Add("@Country", customer.country);
                p.Add("@City", customer.city);
                await con.ExecuteScalarAsync<Customer>(StoreProcedureStatusMessages.UpdateCustomer, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}

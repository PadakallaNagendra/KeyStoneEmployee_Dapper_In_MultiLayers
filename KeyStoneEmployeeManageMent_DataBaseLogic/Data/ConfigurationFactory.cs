using KeyStoneEmployeeManageMent_BusinessObject.InterFace;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_DataBaseLogic.Data
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        private readonly IOptions<Configuration> _options;
        private readonly IConfiguration _config;
        public ConfigurationFactory(IOptions<Configuration> options, IConfiguration config)
        {
            _options = options;
            _config = config;
        }

        public IDbConnection Connection()
        {
            IDbConnection dbConnection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:Customerconnection").Value));
            return dbConnection;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployeeManageMent_BusinessObject.InterFace
{
    public interface IConfigurationFactory
    {
        IDbConnection Connection();
    }
}

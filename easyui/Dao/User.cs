using easyui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyui.Dao
{
    interface User
    {
        Boolean Query(username user);
        Boolean add(username user);
    }
}

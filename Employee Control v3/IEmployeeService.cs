using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Control_v3
{
    interface IEmployeeService
    {
        List<Employee> Search(SearchingEmployee searchingEmployee);
        void Insert(Employee newEmployee);
        void Update(Employee updEmployee);
        void Delete(string _id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeesService : IEmployees
    {
        private static IList<Employee> employees = new List<Employee>
        {
            new Employee {Id="001",Name="Sunteen",Department="CSS",Grade="G7" },
            new Employee {Id="002",Name="Andy",Department="CSS",Grade="G6" }
        };

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }
        public Employee Get(string id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (null == employee)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return employee;
        }
        public void Create(Employee employee)
        {
            employees.Add(employee);
        }
    }
}

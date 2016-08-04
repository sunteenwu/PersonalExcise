using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using EmployeeServiceLibrary;
using System.ServiceModel.Description;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host = new WebServiceHost(typeof(EmployeeServiceLibrary.EmployeesService)))
            {
                //host.AddServiceEndpoint(typeof(IEmployees), new WebHttpBinding(), "http://10.168.174.97/EmployeesService");
                
                //if(host.Description.Behaviors.Find<ServiceMetadataBehavior>()==null)
                //{
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //    behavior.HttpGetEnabled = true;
                //    behavior.HttpGetUrl = new Uri("http://10.168.174.97:8080/EmployeesService/metadata");
                //    host.Description.Behaviors.Add(behavior);
                //}
                //host.Opened += delegate
                //  {
                //      Console.WriteLine("Service already started, press any key to stop service");
                //  };
                host.Open();
                Console.Read();
            }
        }
    }
}

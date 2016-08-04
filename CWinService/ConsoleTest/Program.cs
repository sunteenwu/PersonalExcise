using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            ServiceController sc = new ServiceController("TermService");
            if ((sc.Status.Equals(ServiceControllerStatus.Stopped))
                    || (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                sc.Start();
            }
            else
            {
                sc.Stop();
            }
            sc.Refresh();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfIdentity;

namespace IdentityServiceHost
{
    class Program
    {

        internal static ServiceHost myServiceHost = null;
        static void Main(string[] args)
        {
            NetTcpBinding myBinding = new NetTcpBinding();

            myBinding.Security.Mode = SecurityMode.None;

            myBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;

            Uri baseAddress = new Uri("net.tcp://localhost:8056/WCFService/");

            myServiceHost = new ServiceHost(typeof(GetIdentity), baseAddress);

            ServiceEndpoint myServiceEndpoint = myServiceHost.AddServiceEndpoint

                (typeof(IGetIdentity), myBinding, "GetIdentity");

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();

            behavior.HttpGetEnabled = true;

            behavior.HttpGetUrl = new Uri("http://localhost:8057/mex");

            myServiceHost.Description.Behaviors.Add(behavior);

            myServiceHost.Open();

            Console.WriteLine("Service started!");

            Console.ReadLine();

            myServiceHost.Close();

        }
    }
}

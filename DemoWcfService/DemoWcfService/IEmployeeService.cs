using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DemoWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    //public interface IService1
    //{

    //    [OperationContract]
    //    string GetData(int value);

    //    [OperationContract]
    //    CompositeType GetDataUsingDataContract(CompositeType composite);

    //    // TODO: Add your service operations here
    //}

    public interface IEmployees
    {
        [WebGet(UriTemplate = "all")]
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}")]
        Employee Get(string id);
        [WebInvoke(UriTemplate = "/", Method = "Post")]
        void Create(Employee employee);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

    public class Employee
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string Grade { get; set; }
        public override string ToString()
        {
            return string.Format("ID:{0,-5}Name:{1,-5}Grade:{2,-4} Department:{3}", Id, Name, Grade, Department);
        }

    }
}

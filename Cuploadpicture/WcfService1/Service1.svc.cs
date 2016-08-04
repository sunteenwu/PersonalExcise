using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public ObservableCollection<PromotionList> GetPromotionList()
        {
            ObservableCollection<PromotionList> result = new ObservableCollection<PromotionList>();
            //Add data string here
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = "Server=tcp:cb4m2dfi4p.database.windows.net,1433;Database=garytestSQL_db;User ID=gary@cb4m2dfi4p;Password=123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"; //This one is ado one that copy from the azure
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //Query Here
                String cmdText = "Select * from Promo";
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new PromotionList() { id = dr.GetInt32(0), PromoName = dr.GetString(1) });
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }

            }
            return result;
        }
    }
}

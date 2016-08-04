using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = "Server=tcp:cb4m2dfi4p.database.windows.net,1433;Database=garytestSQL_db;User ID=gary@cb4m2dfi4p;Password=QWEasdzxc123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"; //This one is ado one that copy from the azure
                conn.Open();

                Console.WriteLine("open success");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //Query Here
                //String cmdText = "delete from Promo  ";
                //String cmdText = "     CREATE TABLE Promo(id   INT   PRIMARY KEY,    PromoName VARCHAR(140),    Note      VARCHAR(140));";
                String cmdText = " insert into * Promo values(1, 'test3', 'note3')";
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                // dr.Read();
                while (dr.Read())
                {
                   // result.Add(new PromotionList() { id = dr.GetInt32(0), PromoName = dr.GetString(1) });
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace robot
{
    class Delivery
    {
        public List<string> lists;

        public bool connected = false;
        static private SqlConnection connection;

        public Delivery()
        {
            if (connectDb())
            {
                connected = true;

                lists = new List<string>();
                lists = getDb();
            }
            else
                connected = false;
        }

        private bool connectDb()
        {
            string connectionString = getConnectionString();

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private List<string> getDb()
        {
            string connectString = getConnectionString();

            List<string> lists=new List<string>();

            using (connection = new SqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string queryString = "select * from delivery";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        foreach (DataRow row in dataSet.Tables[0].Rows)
                        {
                            string str="";
                            str += row["index"].ToString() + "," + row["kind"].ToString() + "," + row["name"].ToString() + "," + row["phone_number"].ToString() + "," + row["rating"].ToString();
                            lists.Add(str);
                        }
                    }

                    return lists;
                }
                catch
                {
                    return null;
                }
            }
        }

        static private string getConnectionString()
        {
            return "Data Source=mysql2.000webhost.com;Database=a5608216_deliver;USER ID=a5608216_deliver;PASSWORD=a5608216";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Шашин.Classes
{
    public class Connection
    {
        public List<Order> order = new List<Order>();
        public string localPath = "";

        public enum tabels
        {
            order
        }

        public OleDbDataReader QueryAccess(string query)
        {
            try
            {
                localPath = Directory.GetCurrentDirectory();
                OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + localPath + "/dbOrders.accdb");
                connect.Open();
                OleDbCommand cmd = new OleDbCommand(query, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public void LoadData(tabels zap)
        {
            try
            {
                OleDbDataReader itemQuery = QueryAccess($"SELECT * FROM [{zap.ToString()}] ORDER BY [Код]");

                order.Clear();
                while (itemQuery.Read())
                {
                    Order newOrder = new Order();
                    newOrder.Id = Convert.ToInt32(itemQuery.GetValue(0));
                    newOrder.fio_user = Convert.ToString(itemQuery.GetValue(1));
                    newOrder.message_text = Convert.ToString(itemQuery.GetValue(2));
                    newOrder.adress = Convert.ToString(itemQuery.GetValue(3));
                    newOrder.dateSendMessage = Convert.ToString(itemQuery.GetValue(4));
                    newOrder.email = Convert.ToString(itemQuery.GetValue(5));
                    order.Add(newOrder);
                }

                if (itemQuery != null) itemQuery.Close();
            }
            catch
            {
                Console.WriteLine("NULL");
            }
        }

        public int SetActualId(tabels tabel)
        {
            try
            {
                LoadData(tabel);
                if (order.Count >= 1)
                {
                    int max_status = order[0].Id;
                    max_status = order.Max(x => x.Id);
                    return max_status + 1;
                } else return 1;
            } catch
            {
                return -1;
            }
        }
    }
}

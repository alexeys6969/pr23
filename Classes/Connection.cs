using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    newOrder.dateSendMessage = Convert.ToDateTime(itemQuery.GetValue(4));
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

        public bool ItsFio(string fio)
        {
            return Regex.IsMatch(fio.Trim(), @"^[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+$");
        }

        public bool ItsDateTime(string dateStr)
        {
            return Regex.IsMatch(dateStr.Trim(), @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d{2}\s([01][0-9]|2[0-3])\:[0-5][0-9]$");
        }

        public bool ItsEmail(string email)
        {
            return Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}

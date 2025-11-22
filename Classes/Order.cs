using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Шашин.Classes
{
    public class Order
    {
        public string fio_user {  get; set; }
        public string message_text { get; set; }
        public string adress {  get; set; }
        public DateTime date_Send_Message { get; set;  }
        public string email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Шашин.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public string fio_user {  get; set; }
        public string message_text { get; set; }
        public string adress {  get; set; }
        public DateTime dateSendMessage { get; set;  }
        public string email { get; set; }
    }
}

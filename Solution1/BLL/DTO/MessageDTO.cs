using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int MessageID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}

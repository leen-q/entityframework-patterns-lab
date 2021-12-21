using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class Message
    {
        public int MessageID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public IMessageStrategy Type { private get; set; }

        public Message(int message, DateTime date, string subject, string text, IMessageStrategy type)
        {
            MessageID = message;
            Date = date;
            Subject = subject;
            Text = text;
            Type = type;
        }

        public void MessType()
        {
            foreach (var prop in typeof(Message).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
            }
            Type.MessType();
        }
        
    }
}

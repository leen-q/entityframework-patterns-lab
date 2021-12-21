using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public enum MessState
    {
        NEW,
        NONPUBLISHED,
        PUBLISHED,
        DELETED,
    }

    public class Message : IMessagePrototype
    {
        public int MessageID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public MessState State { get; set; }

        public Message(int message, DateTime date, string subject, string text, MessState state)
        {
            MessageID = message;
            Date = date;
            Subject = subject;
            Text = text;
            State = state;
        }
        
        public IMessagePrototype Clone()
        {
            return new Message(this.MessageID, this.Date, this.Subject, this.Text, this.State);
        }

        public void MessageManager()
        {
            if (this.State == MessState.NEW)
            {
                Console.WriteLine("Створений шаблон повiдомлення!");
                this.State = MessState.NONPUBLISHED;
                foreach (var prop in typeof(Message).GetProperties())
                {
                    Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
                }
            }
            else if (this.State == MessState.NONPUBLISHED)
            {
                Console.WriteLine("\nБажаєте вiдправавити чи видалити оголошення?");
                Console.WriteLine("1 - вiдправити; 2 - видалити");
                var option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    this.State = MessState.PUBLISHED;
                }
                else
                {
                    this.State = MessState.DELETED;
                }
            }
            else if (this.State == MessState.PUBLISHED)
            {
                foreach (var prop in typeof(Message).GetProperties())
                {
                    Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
                }
            }
            else
            {
                Console.WriteLine("Повiдомлення видалене!");
                foreach (var prop in typeof(Message).GetProperties())
                {
                    Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
                }
            }
            
        }

    }
}

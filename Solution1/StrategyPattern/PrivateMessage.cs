using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace StrategyPattern
{
    public class PrivateMessage : IMessageStrategy
    {
        public string Address { get; set; }
        public void MessType()
        {
            Console.WriteLine("Введiть отримувача: ");
            this.Address = Console.ReadLine();
            foreach (var prop in typeof(PrivateMessage).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
            }
        }
    }
}

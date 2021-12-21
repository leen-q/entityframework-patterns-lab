using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace StrategyPattern
{
    public class PublicMessage : IMessageStrategy
    {
        public string Address { get; set; }

        public void MessType()
        {
            this.Address = "all";
            foreach (var prop in typeof(PublicMessage).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(this));
            }
        }

    }
}

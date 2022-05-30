using System;
using DAL.Entities;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Message mess = new Message(1, DateTime.Now, "test", "test", new PublicMessage());
            mess.MessType();

            Console.WriteLine("\n");

            mess.Type = new PrivateMessage();
            mess.MessType();
        }
    }
}

using System;
using DAL.Entities;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Message mess = new Message(1, DateTime.Now, "test", "test", MessState.NEW);
            mess.MessageManager();
            mess.MessageManager();
            mess.MessageManager();
        }
    }
}

using System;
using BLL.Services.ImplS;
using BLL.Services.Interfaces;
using DAL.Entities;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade(new PersonalData(), new WorkData());
            facade.CreateUser();
        }
    }
}

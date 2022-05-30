using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace FacadePattern
{
    public class Facade
    {
        private PersonalData pd;
        private WorkData wd;

        public Facade (PersonalData per, WorkData wor)
        {
            pd = per;
            wd = wor;
        }

        public void CreatePersonalData()
        {
            pd.Name = "placeHolder";
            pd.Surname = "placeHolder";
            pd.Email = "placeHolder";
            pd.Birthday = new DateTime(2000, 1, 1);

            foreach (var prop in typeof(PersonalData).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(pd));
            }
        }

        public void CreateWorkData()
        {
            wd.Post = "placeHolder";
            wd.Salary = 0;

            foreach (var prop in typeof(WorkData).GetProperties())
            {
                Console.WriteLine(prop.Name + " - " + prop.GetValue(wd));
            }
        }

        public void CreateUser()
        {
            this.CreatePersonalData();
            this.CreateWorkData();
            Console.WriteLine("\nКористувач створений!");
        }
    }
}

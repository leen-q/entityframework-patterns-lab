using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly IUnitOfWork _database;
        

        public PersonalDataService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public void AddPersonalData(PersonalDataDTO personaldataDto)
        {
            PersonalData per_d = new PersonalData
            {
                Name = personaldataDto.Name,
                Surname = personaldataDto.Surname,
                Birthday = personaldataDto.Birthday,
                Email = personaldataDto.Email
            };

            _database.Personaldata.Create(per_d);
            _database.Save();
        }

        public PersonalDataDTO GetPersonalData(int id)
        {
            var per_d = _database.Personaldata.Get(id);
            return new PersonalDataDTO { Name = per_d.Name, Surname = per_d.Surname, Birthday = per_d.Birthday, Email = per_d.Email, PersonalDataID = per_d.PersonalDataID };
        }

        public void ChangePersonalData(int id, PersonalDataDTO personaldataDto)
        {
            var per_d = _database.Personaldata.Get(id);

            per_d.Name = personaldataDto.Name;
            per_d.Surname = personaldataDto.Surname;
            per_d.Email = personaldataDto.Email;
            per_d.Birthday = personaldataDto.Birthday;

            _database.Save();
        }
    }
}

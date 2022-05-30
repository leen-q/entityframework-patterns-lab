using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IPersonalDataService
    {
        void AddPersonalData(PersonalDataDTO personaldataDto);
        PersonalDataDTO GetPersonalData(int id);
        void ChangePersonalData(int id, PersonalDataDTO personaldataDto);
    }
}

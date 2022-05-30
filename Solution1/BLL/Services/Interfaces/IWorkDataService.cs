using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IWorkDataService
    {
        void AddWorkData(WorkDataDTO workdataDto);
        WorkDataDTO GetWorkData(int id);
        void ChangeWorkData(int id, WorkDataDTO workdataDto);
    }
}

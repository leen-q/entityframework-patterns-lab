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
    public class WorkDataService : IWorkDataService
    {
        private readonly IUnitOfWork _database;


        public WorkDataService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public void AddWorkData(WorkDataDTO workdataDto)
        {
            WorkData work_d = new WorkData
            {
                Post = workdataDto.Post,
                Salary = workdataDto.Salary
            };

            _database.Workdata.Create(work_d);
            _database.Save();
        }

        public WorkDataDTO GetWorkData(int id)
        {
            var work_d = _database.Workdata.Get(id);
            return new WorkDataDTO { WorkDataID = work_d.WorkDataID, Salary = work_d.Salary, Post = work_d.Post };
        }

        public void ChangeWorkData(int id, WorkDataDTO workdataDto)
        {
            var work_d = _database.Workdata.Get(id);

            work_d.Post = workdataDto.Post;
            work_d.Salary = workdataDto.Salary;
            work_d.WorkDataID = workdataDto.WorkDataID;
            
            _database.Save();
        }
    }
}

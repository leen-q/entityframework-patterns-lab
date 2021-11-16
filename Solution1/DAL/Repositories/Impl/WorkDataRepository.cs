using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class WorkDataRepository : BaseRepository<WorkData>, IWorkDataRepository
    {

        internal WorkDataRepository(DataContext context) : base(context)
        {
        }
    }
}

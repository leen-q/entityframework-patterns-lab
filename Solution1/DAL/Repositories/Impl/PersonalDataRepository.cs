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
    public class PersonalDataRepository : BaseRepository<PersonalData>, IPersonalDataRepository
    {

        internal PersonalDataRepository(DataContext context) : base(context)
        {
        }
    }
}

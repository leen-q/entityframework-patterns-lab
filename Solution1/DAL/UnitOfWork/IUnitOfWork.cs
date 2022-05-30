using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonalDataRepository Personaldata { get; }
        IWorkDataRepository Workdata { get; }
        IMessageRepository Message { get; }
        void Save();
    }
}

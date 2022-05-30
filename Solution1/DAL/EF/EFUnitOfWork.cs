using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DataContext db;
        private PersonalDataRepository personaldataRepository;
        private WorkDataRepository workdataRepository;
        private MessageRepository messageRepository;

        public EFUnitOfWork(DataContext context)
        {
            db = context;
        }
        public IPersonalDataRepository Personaldata
        {
            get
            {
                if (personaldataRepository == null)
                    personaldataRepository = new PersonalDataRepository(db);
                return personaldataRepository;
            }
        }

        public IWorkDataRepository Workdata
        {
            get
            {
                if (workdataRepository == null)
                    workdataRepository = new WorkDataRepository(db);
                return workdataRepository;
            }
        }

        public IMessageRepository Message
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

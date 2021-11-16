using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Xunit;
using Moq;

namespace DAL.Tests
{
    class TestPersonalDataRepository : BaseRepository<PersonalData>
    {
        public TestPersonalDataRepository(DbContext context) : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTest
    {
        [Fact]
        public void Create_InputPersonalDataInstance_CalledAddMethodOfDBSetWithPersonalDataInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<DataContext>().Options;
            var mockContext = new Mock<DataContext>(opt);
            var mockDbSet = new Mock<DbSet<PersonalData>>();
            mockContext.Setup(context =>context.Set<PersonalData>()).Returns(mockDbSet.Object);

            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestPersonalDataRepository(mockContext.Object);

            PersonalData expectedPersonalData = new Mock<PersonalData>().Object;

            repository.Create(expectedPersonalData);

            mockDbSet.Verify(dbSet => dbSet.Add(expectedPersonalData), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<DataContext>().Options;
            var mockContext = new Mock<DataContext>(opt);
            var mockDbSet = new Mock<DbSet<PersonalData>>();
            mockContext.Setup(context => context.Set<PersonalData>()).Returns(mockDbSet.Object);

            PersonalData expectedPersonalData = new PersonalData() { PersonalDataID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPersonalData.PersonalDataID)).Returns(expectedPersonalData);
            var repository = new TestPersonalDataRepository(mockContext.Object);

            var actualStreet = repository.Get(expectedPersonalData.PersonalDataID);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedPersonalData.PersonalDataID), Times.Once());
            Assert.Equal(expectedPersonalData, actualStreet);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<DataContext>().Options;
            var mockContext = new Mock<DataContext>(opt);
            var mockDbSet = new Mock<DbSet<PersonalData>>();
            mockContext.Setup(context => context.Set<PersonalData>()).Returns(mockDbSet.Object);

            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;

            var repository = new TestPersonalDataRepository(mockContext.Object);

            PersonalData expectedPersonalData = new PersonalData() { PersonalDataID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPersonalData.PersonalDataID)).Returns(expectedPersonalData);

            repository.Delete(expectedPersonalData.PersonalDataID);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedPersonalData.PersonalDataID), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedPersonalData), Times.Once());
        }
    }
}

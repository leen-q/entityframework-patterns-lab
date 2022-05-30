using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.ImplS;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class MessageServiceTest
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new MessageService(nullUnitOfWork));
        }

        [Fact]
        public void GetMessage_UserIsAdmin_ThrowMethodAccessException()
        {
            User user = new Admin(1, "test", "test");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IMessageService messageService = new MessageService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => messageService.GetMessages(0));
        }
    }
}

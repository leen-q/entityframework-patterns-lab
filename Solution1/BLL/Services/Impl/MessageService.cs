using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.ImplS
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public MessageService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public void AddMessage(MessageDTO messageDto)
        {
            Message mess = new Message(messageDto.MessageID, DateTime.Now, messageDto.Subject, messageDto.Text);

            _database.Message.Create(mess);
            _database.Save();
        }

        public IEnumerable<MessageDTO> GetMessages(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director) && userType != typeof(Worker))
            {
                throw new MethodAccessException();
            }
            var messageEntities = _database.Message.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Message, MessageDTO>()).CreateMapper();
            var messagesDto = mapper.Map<IEnumerable<Message>, List<MessageDTO>>(messageEntities);
            return messagesDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IMessageService
    {
        void AddMessage(MessageDTO messageDto);
        IEnumerable<MessageDTO> GetMessages(int page);
    }
}

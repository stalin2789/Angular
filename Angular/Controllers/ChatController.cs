using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private Models.MyDBContext db;

        public ChatController(Models.MyDBContext context)
        {
            this.db = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<MessageViewModel> Message()
        {
            List<MessageViewModel> lst = (from m in db.Message
                                         select new MessageViewModel
                                         {
                                             Id = m.Id,
                                             Name = m.Name,
                                             MessageContent = m.MessageContent
                                         }).ToList();
            return lst;
        }
    }
}

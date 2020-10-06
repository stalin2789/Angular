using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models.Response;
using Angular.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
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
                                          orderby m.Id descending   
                                         select new MessageViewModel
                                         {
                                             Id = m.Id,
                                             Name = m.Name,
                                             MessageContent = m.MessageContent
                                         }).ToList();
            return lst;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]MessageViewModel model)
        {
            MyResponse response = new MyResponse();

            try
            {
                Models.Message message = new Models.Message();
                message.Name = model.Name;
                message.MessageContent = model.MessageContent;

                db.Message.Add(message);
                db.SaveChanges();

                response.Success = 1;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Message = "Ocurrio un error: " + ex.Message;
            }

            return response;


        }
    }
}

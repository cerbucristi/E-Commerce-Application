using ECommerce.API.Contracts;
using ECommerce.API.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{

    [EnableCors("Open")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
       
        public MailController(IMailService _MailService)
        {
            _mailService = _MailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public bool SendMail(MailData mailData)
        {
            return _mailService.SendMail(mailData);
        }
    }
}

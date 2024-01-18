using ECommerce.Application.Models;

namespace ECommerce.Application.Contracts
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}

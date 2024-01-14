

using ECommerce.API.Utility;

namespace ECommerce.API.Contracts
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}

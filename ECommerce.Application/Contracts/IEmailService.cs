using ECommerce.Application.Models;

namespace ECommerce.Application.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Mail email);
    }
}

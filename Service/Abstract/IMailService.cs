using System.Threading.Tasks;
using Caravan.Models;

namespace Caravan.Interfaces
{
    public interface IMailService
    {
        void SendMail(EmailConfiguration config);
    }
}
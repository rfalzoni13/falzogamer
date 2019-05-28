using System.Collections.Generic;
using System.Threading.Tasks;

namespace FalzoGamer.Admin.Models.MailKit.Interfaces
{
    public interface IEmailServico
    {
        void Send(MensagemEmail mensagemEmail);
        Task SendAsync(MensagemEmail mensagemEmail);
        List<MensagemEmail> ReceiveEmail(int maxCount = 10);
    }
}

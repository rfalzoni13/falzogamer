using System.Collections.Generic;

namespace FalzoGamer.Admin.Models.MailKit.Interfaces
{
    public interface IEmailServico
    {
        void Send(MensagemEmail mensagemEmail);
        List<MensagemEmail> ReceiveEmail(int maxCount = 10);
    }
}

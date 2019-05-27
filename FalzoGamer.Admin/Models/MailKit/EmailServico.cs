using System.Collections.Generic;
using System.Linq;
using FalzoGamer.Admin.Models.MailKit.Interfaces;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace FalzoGamer.Admin.Models.MailKit
{
    public class EmailServico : IEmailServico
    {
        private readonly IEmailConfiguracao _emailConfiguracao;

        public EmailServico(IEmailConfiguracao emailConfiguracao)
        {
            _emailConfiguracao = emailConfiguracao;
        }

        public List<MensagemEmail> ReceiveEmail(int maxCount = 10)
        {
            using (var emailClient = new Pop3Client())
            {
                emailClient.Connect(_emailConfiguracao.PopServer, _emailConfiguracao.PopPort, true);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguracao.PopUsername, _emailConfiguracao.PopPassword);

                List<MensagemEmail> emails = new List<MensagemEmail>();
                for (int i = 0; i < emailClient.Count && i < maxCount; i++)
                {
                    var message = emailClient.GetMessage(i);
                    var emailMessage = new MensagemEmail
                    {
                        Conteudo = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                        Assunto = message.Subject
                    };
                    emailMessage.ParaEndereco.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EnderecoEmail { Endereco = x.Address, Nome = x.Name }));
                    emailMessage.DeEndereco.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EnderecoEmail { Endereco = x.Address, Nome = x.Name }));
                }

                return emails;
            }
        }

        public void Send(MensagemEmail mensagemEmail)
        {
            var message = new MimeMessage();
            message.To.AddRange(mensagemEmail.ParaEndereco.Select(x => new MailboxAddress(x.Nome, x.Endereco)));
            message.From.AddRange(mensagemEmail.DeEndereco.Select(x => new MailboxAddress(x.Nome, x.Endereco)));

            message.Subject = mensagemEmail.Assunto;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = mensagemEmail.Conteudo
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_emailConfiguracao.SmtpServer, _emailConfiguracao.SmtpPort, false);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguracao.SmtpUsername, _emailConfiguracao.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}

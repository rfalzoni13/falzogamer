using System.Collections.Generic;

namespace FalzoGamer.Admin.Models.MailKit
{
    public class MensagemEmail
    {
        public MensagemEmail()
        {
            DeEndereco = new List<EnderecoEmail>();
            ParaEndereco = new List<EnderecoEmail>();
        }

        public List<EnderecoEmail> DeEndereco { get; set; }
        public List<EnderecoEmail> ParaEndereco { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
    }
}

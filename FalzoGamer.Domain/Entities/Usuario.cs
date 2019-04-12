using FalzoGamer.Domain.Entities.Base;

namespace FalzoGamer.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public int AcessoId { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual Vendedor Vendedor { get; set; }

        public virtual Acesso Acesso { get; set; }
    }
}

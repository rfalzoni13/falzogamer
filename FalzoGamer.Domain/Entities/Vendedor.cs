using FalzoGamer.Domain.Entities.Base;

namespace FalzoGamer.Domain.Entities
{
    public class Vendedor : EntityBase
    {
        public int UsuarioId { get; set; }

        public long Cpf { get; set; }

        public long? Telefone { get; set; }

        public long Celular { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

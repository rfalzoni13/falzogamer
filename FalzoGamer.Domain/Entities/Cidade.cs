using FalzoGamer.Domain.Entities.Base;

namespace FalzoGamer.Domain.Entities
{
    public class Cidade : EntityBase
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public virtual Estado Estado { get; set; }
    }
}

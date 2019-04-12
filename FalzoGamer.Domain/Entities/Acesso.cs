using FalzoGamer.Domain.Entities.Base;

namespace FalzoGamer.Domain.Entities
{
    public class Acesso : EntityBase
    {
        public string Nome { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

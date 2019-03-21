using System;

namespace FalzoGamer.Domain.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }

        public bool Novo { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}

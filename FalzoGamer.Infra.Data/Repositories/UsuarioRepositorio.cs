using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Infra.Data.Repositories.Base;

namespace FalzoGamer.Infra.Data.Repositories
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
    }
}

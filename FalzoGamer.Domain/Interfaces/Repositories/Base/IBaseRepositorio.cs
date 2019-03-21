using System.Collections.Generic;

namespace FalzoGamer.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepositorio<T> where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Apagar(T obj);

        T BuscarPorId(int id);

        IEnumerable<T> BuscarTodos();
    }
}

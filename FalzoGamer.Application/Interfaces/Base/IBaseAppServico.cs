using System;
using System.Collections.Generic;

namespace FalzoGamer.Application.Interfaces.Base
{
    public interface IBaseAppServico<T> : IDisposable where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Apagar(T obj);

        T BuscarPorId(int id);

        IEnumerable<T> BuscarTodos();
    }
}

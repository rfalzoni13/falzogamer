﻿using System;
using System.Collections.Generic;

namespace FalzoGamer.Domain.Interfaces.Services.Base
{
    public interface IServicoBase<T> : IDisposable where T : class
    {
        void Adicionar(T obj);

        void Atualizar(T obj);

        void Apagar(T obj);

        T BuscarPorId(int id);

        IEnumerable<T> BuscarTodos();

    }
}

using FalzoGamer.Domain.Interfaces;
using FalzoGamer.Domain.Interfaces.Repositories.Base;
using FalzoGamer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FalzoGamer.Infra.Data.Repositories.Base
{
    public class BaseRepositorio<T> : IDisposable, IBaseRepositorio<T> where T : class
    {
        #region Attributes
        protected FalzoGamerContext Context { get; private set; }

        private IFalzoGamerContext falzoGamerContext { get; set; }
        #endregion

        #region Constructor
        public BaseRepositorio()
        {
            Context = new FalzoGamerContext();
        }

        public BaseRepositorio(IFalzoGamerContext falzoGamerContext)
        {
            this.falzoGamerContext = falzoGamerContext;
        }
        #endregion

        public void Adicionar(T obj)
        {
            Context.Set<T>().Add(obj);
            Context.SaveChanges();
        }

        public void Apagar(T obj)
        {
            Context.Set<T>().Remove(obj);
            Context.SaveChanges();
        }   

        public void Atualizar(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public T BuscarPorId(int id) => Context.Set<T>().Find(id);

        public IEnumerable<T> BuscarTodos() => Context.Set<T>().ToList();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if(!status)
            {
                return;
            }
        }
    }
}

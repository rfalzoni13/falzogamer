using System;
using System.Collections.Generic;
using FalzoGamer.Domain.Interfaces.Repositories.Base;
using FalzoGamer.Domain.Interfaces.Services.Base;

namespace FalzoGamer.Services.Base
{
    public class ServicoBase<T> : IServicoBase<T> where T : class
    {
        #region Atributos
        private readonly IBaseRepositorio<T> _baseRepositorio;
        #endregion

        #region Construtor
        public ServicoBase(IBaseRepositorio<T> repositorio)
        {
            _baseRepositorio = repositorio;
        }
        #endregion

        public virtual void Adicionar(T obj)
        {
            if(obj != null)
            {
                _baseRepositorio.Adicionar(obj);
            }
            else
            {
                throw new ArgumentException("Parâmtro inválido");
            }
        }

        public virtual void Apagar(T obj)
        {
            if (obj != null)
            {
                _baseRepositorio.Apagar(obj);
            }
            else
            {
                throw new ArgumentException("Parâmtro inválido");
            }
        }

        public virtual void Atualizar(T obj)
        {
            if (obj != null)
            {
                _baseRepositorio.Atualizar(obj);
            }
            else
            {
                throw new ArgumentException("Parâmtro inválido");
            }
        }

        public virtual T BuscarPorId(int id) => id > 0 ? _baseRepositorio.BuscarPorId(id) :
            throw new ArgumentException("Parâmetro inválid");

        public virtual IEnumerable<T> BuscarTodos() => _baseRepositorio.BuscarTodos();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if (!status)
            {
                return;
            }
        }
    }
}

using FalzoGamer.Application.Interfaces.Base;
using FalzoGamer.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace FalzoGamer.Application.AppServices.Base
{
    public class BaseAppServico<T> : IBaseAppServico<T> where T : class
    {
        #region Atributos
        private readonly IServicoBase<T> _servicoBase;
        #endregion

        #region Construtor
        public BaseAppServico(IServicoBase<T> servicoBase)
        {
            _servicoBase = servicoBase;
        }
        #endregion

        public void Adicionar(T obj)
        {
            _servicoBase.Adicionar(obj);
        }

        public void Apagar(T obj)
        {
            _servicoBase.Apagar(obj);
        }

        public void Atualizar(T obj)
        {
            _servicoBase.Atualizar(obj);
        }

        public T BuscarPorId(int id) => _servicoBase.BuscarPorId(id);

        public IEnumerable<T> BuscarTodos() => _servicoBase.BuscarTodos();

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}

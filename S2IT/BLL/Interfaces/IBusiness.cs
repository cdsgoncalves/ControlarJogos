using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    /// <summary>
    /// Interface que expõe os metodos base da business
    /// </summary>
    public interface IBusiness<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> where);
    }
}
using System;
using PagedList;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Interfaces
{
    /// <summary>
    /// Interface que expões os métodos básicos de repositório
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona a entidade
        /// </summary>
        void Adicionar(TEntity obj);
        /// <summary>
        /// Exclui a entidade
        /// </summary>
        void Excluir(TEntity obj);
        /// <summary>
        /// Edita a entidade
        /// </summary>
        void Atualizar(TEntity obj);
        /// <summary>
        /// Obtém a entidade por Id
        /// </summary>
        TEntity ObterPorId(object id);
        /// <summary>
        /// Obtem a entidade pelo expressão do where informada
        /// </summary>
        TEntity Obter(Expression<Func<TEntity, bool>> where, bool desabilitarRastreamento = false);
        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        IEnumerable<TEntity> ObterLista();
        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        IQueryable<TEntity> ObterListaQueryable();
        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        IQueryable<TEntity> ObterListaQueryable(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// Obtem a lista da entidade pelo expressão do where informada
        /// </summary>
        IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> where, bool desabilitarRastreamento = false);
        /// <summary>
        /// Obtem a lista da entidade pelo expressão do where e ordem
        /// </summary>
        IEnumerable<TEntity> ObterLista<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem);
        /// <summary>
        /// Obtem a lista da entidade pelo expressão do where e ordem e permite desabilitar o rastreamento do ORM
        /// </summary>
        IEnumerable<TEntity> ObterLista<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool desabilitarRastreamento);
        /// <summary>
        /// Retorna a lista da entidade paginada
        /// </summary>
        IPagedList<TEntity> Paginar<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, int paginaAtual, int tamanhoItensPagina);
        /// <summary>
        /// Verifica se a entidade existe com o where informado
        /// </summary>
        bool VerificarExistencia(Expression<Func<TEntity, bool>> where);
    }
}
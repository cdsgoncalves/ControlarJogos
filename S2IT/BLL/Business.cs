using System;
using BLL.Interfaces;
using DAL.Interfaces;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Implementação da Business base
    /// </summary>
    public abstract class Business<TEntity> : IBusiness<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        protected Business(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adiciona uma entidade no banco de dados.
        /// </summary>
        public virtual void Adicionar(TEntity obj) => _repository.Adicionar(obj);

        /// <summary>
        /// Atualiza uma entidade no banco de dados
        /// </summary>
        public virtual void Atualizar(TEntity obj) => _repository.Atualizar(obj);

        /// <summary>
        /// Obtém uma entidade pelo seu ID
        /// </summary>
        public virtual TEntity ObterPorId(int id) => _repository.ObterPorId(id);

        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        public virtual IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> where) => _repository.ObterLista(where);
    }
}
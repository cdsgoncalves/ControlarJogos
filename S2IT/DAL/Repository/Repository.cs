using System;
using PagedList;
using System.Linq;
using DAL.Contexts;
using DAL.Interfaces;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DAL.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly S2ItContext _contexto;

        protected Repository(S2ItContext contexto)
        {
            _contexto = contexto;
        }

        public DbContext Contexto => _contexto;

        public void Adicionar(TEntity obj) => Contexto.Set<TEntity>().Add(obj);

        public virtual void Atualizar(TEntity obj)
        {
            var entry = _contexto.Entry(obj);
            _contexto.Set<TEntity>().Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Excluir(TEntity obj) => Contexto.Set<TEntity>().Remove(obj);

        public TEntity Obter(Expression<Func<TEntity, bool>> where, bool desabilitarRastreamento = false)
        {
            IQueryable<TEntity> query = Contexto.Set<TEntity>();

            if (desabilitarRastreamento)
                query = query.AsNoTracking();

            return query.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> where, bool desabilitarRastreamento = false)
        {
            IQueryable<TEntity> query = Contexto.Set<TEntity>();

            if (desabilitarRastreamento)
                query = query.AsNoTracking();

            return query.Where(where).ToArray();
        }

        public IEnumerable<TEntity> ObterLista<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem) => ObterLista(where, ordem, false);

        public IEnumerable<TEntity> ObterLista<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool desabilitarRastreamento)
        {
            IQueryable<TEntity> query = Contexto.Set<TEntity>();

            if (desabilitarRastreamento)
                query = query.AsNoTracking();

            return query.Where(where).OrderBy(ordem).ToArray();
        }

        public IEnumerable<TEntity> ObterLista() => Contexto.Set<TEntity>().ToArray();

        public IQueryable<TEntity> ObterListaQueryable() => Contexto.Set<TEntity>().AsNoTracking().AsQueryable();

        public IQueryable<TEntity> ObterListaQueryable(Expression<Func<TEntity, bool>> where) => Contexto.Set<TEntity>().Where(where).AsQueryable();

        public TEntity ObterPorId(object id) => Contexto.Set<TEntity>().Find(id);

        public IPagedList<TEntity> Paginar<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, int paginaAtual, int tamanhoItensPagina)
        {
            return Contexto
                .Set<TEntity>()
                .AsNoTracking()
                .Where(where)
                .OrderBy(ordem)
                .ToPagedList(paginaAtual, tamanhoItensPagina);
        }

        public bool VerificarExistencia(Expression<Func<TEntity, bool>> where) => Contexto.Set<TEntity>().Where(where).Any();
    }
}
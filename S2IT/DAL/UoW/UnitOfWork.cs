using System;
using DAL.Contexts;
using Infra.Interfaces;

namespace DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private S2ItContext _contexto;

        public UnitOfWork(S2ItContext contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        #region === Dispose ===
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _contexto == null)
                return;

            _contexto.Dispose();
            _contexto = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
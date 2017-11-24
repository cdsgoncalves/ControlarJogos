using System;

namespace Infra.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
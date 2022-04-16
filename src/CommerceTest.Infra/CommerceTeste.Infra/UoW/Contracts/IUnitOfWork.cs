using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.UoW.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        public void Roolback();
    }
}

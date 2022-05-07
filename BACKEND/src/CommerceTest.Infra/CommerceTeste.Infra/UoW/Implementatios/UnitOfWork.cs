using CommerceTeste.Infra.Data.Context;
using CommerceTeste.Infra.UoW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceTeste.Infra.UoW.Implementatios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var changes = await _context.SaveChangesAsync(); 

            return changes > 0;
        }

        public void Roolback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

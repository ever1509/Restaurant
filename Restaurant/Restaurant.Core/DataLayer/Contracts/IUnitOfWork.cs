using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Int32 CommitChanges();
        Task<Int32> CommitChangesAsync();
    }
}

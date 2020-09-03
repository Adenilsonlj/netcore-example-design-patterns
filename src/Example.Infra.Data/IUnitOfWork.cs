using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data
{
    public interface IUnitOfWork
    {
        ExampleContext Context { get; }
        Task CommitAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ExampleContext Context { get; set; }

        public UnitOfWork(ExampleContext context)
        {
            Context = context;
        }

        public async Task CommitAsync()
        {
            using (var transaction = await this.Context.Database.BeginTransactionAsync())
            {
                try
                {
                    await this.Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}

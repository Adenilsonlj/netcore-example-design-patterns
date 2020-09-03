using Example.Application.Example.Repository;
using Example.Domain.ExampleAggregate;
using Example.Infra.Data.Repositories.Base;

namespace Example.Infra.Data.Repositories
{
    public class ExampleRepository : BaseRepository<ExampleDomain>, IExampleRepository
    {
        public ExampleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}

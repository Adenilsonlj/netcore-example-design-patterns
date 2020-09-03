using Example.Domain.ExampleAggregate;
using Example.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Application.Example.Repository
{
    public interface IExampleRepository : IBaseRepository<ExampleDomain>
    {
    }
}

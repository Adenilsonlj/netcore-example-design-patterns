using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.ExampleAggregate
{
    public class ExampleValidator : AbstractValidator<ExampleDomain>
    {
        public ExampleValidator()
        {
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("TESTE123");
        }
    }
}

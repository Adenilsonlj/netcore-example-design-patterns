using Example.Domain.ExampleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Application.Example.Models.Dtos
{
    public class ExampleDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public static explicit operator ExampleDto(ExampleDomain v)
        {
            return new ExampleDto()
            {
                Id = v.Id,
                Age = v.Age,
                Name = v.Name
            };
        }
    }
}

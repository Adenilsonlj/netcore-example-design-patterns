using Abp.Domain.Entities;
using Example.Domain.SeedWork;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;

namespace Example.Domain.ExampleAggregate
{
    public class ExampleDomain : DomainBase
    {
        public ExampleDomain(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public static ExampleDomain Create(int age, string name) => new ExampleDomain(age, name);

        public void Update(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}

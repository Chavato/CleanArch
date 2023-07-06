using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ValidateDomain(name);
            Id = id;
            Name = name;
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                                           "Invalid name, too short, minimum 3 characters");

        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

    }
}
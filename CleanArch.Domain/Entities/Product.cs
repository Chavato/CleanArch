using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;
namespace CleanArch.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name,
                       string description,
                       decimal price,
                       int stock,
                       string image)
        {
            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public Product(int id,
                       string name,
                       string description,
                       decimal price,
                       int stock,
                       string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name,
                           string description,
                           decimal price,
                           int stock,
                           string image,
                           int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name,
                                    string description,
                                    decimal price,
                                    int stock,
                                    string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3,
                                           "Invalid name, too short, minumum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid description. description is required.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid description, too short, minumum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
using FluentAssertions;
using CleanArch.Domain.Entities;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                  .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Negative Id")]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid id value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minumum 3 characters");

            Action action2 = () => new Product(1, "", "Product Description", 9.99m, 99, "Product Image");
            action2.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Description")]
        public void CreateProduct_WithInvalidDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Product Name", "Pr", 9.99m, 99, "Product Image");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid description, too short, minumum 5 characters");

            Action action2 = () => new Product(1, "Product  Name", "", 9.99m, 99, "Product Image");
            action2.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_WithNegativePriceValue_DomainExceptionInvalidPriceS()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1m, 99, "Product Image");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_WithNegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "Product Image");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid stock value.");
        }


        [Fact(DisplayName = "Create Product With Long Image String")]
        public void CreateProduct_WithLongImageString_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1,
                                              "Product Name",
                                              "Product Description",
                                              9.99m,
                                              99,
                                              "Product Image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooongggggggggggggggggggggggggggggggg");
            action.Should()
                  .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImageValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                  .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImageValue_NullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                  .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Empty Image Name")]
        public void CreateProduct_WithNullEmptyImageValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                  .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

    }
}
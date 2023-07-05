using CleanArch.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");

        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();

    }

    [Fact(DisplayName = "Create Category With Id Negative")]
    public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");

        action.Should()
              .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid id value.");
    }

    [Fact(DisplayName = "Create Category With Short Name")]
    public void CreateCategory_WithShortNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "AB");

        action.Should()
              .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category With Empty Name")]
    public void CreateCategory_WithEmptyNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "");

        action.Should()
              .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid name. Name is required.");

    }

    [Fact(DisplayName = "Create Category With Null Name")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null );

        action.Should()
              .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid name. Name is required.");

    }
}
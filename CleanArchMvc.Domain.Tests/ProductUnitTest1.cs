using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Sdk;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParamiters_ResultOjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainExceptionInvalidPriceValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
                .WithMessage("Invalid stock value.");
        }

        [Fact]
        public void CreateProduct_WithNullImage_NotDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NotNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NotDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainValidationException>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Domain.Models;

public class Product
{
    #region Properties
    public long IdProduct { get; set; }
    public long IdCategory { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime DateRegistration { get; set; }
    #endregion

    #region Navigation Properties

    // 1 Produto tem 1 categoria
    public Category Category { get; set; }

    #endregion
    
    public void ToUpdate(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.IdCategory)
            .GreaterThan(0).WithMessage("A Categoria deve ser preenchida");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The Category must be filled in.")
            .MaximumLength(50).WithMessage("The maximum allowed size for the product name is 50 characters.");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The product description field cannot be empty.")
            .MaximumLength(100).WithMessage("The maximum allowed size for the product description is 100 characters.");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The price field must be filled in.");
        
        RuleFor(x => x.DateRegistration)
            .NotEmpty().WithMessage("Registration is mandatory.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The registration date cannot be in the future.");
    }
}
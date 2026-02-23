using FluentValidation;

namespace CleanArchitecture.Domain.Models;

public class Category
{
    #region Properties
    public long IdCategory { get; set; }
    public string Description { get; set; }
    public DateTime DateRegistration { get; set; }
    #endregion

    #region Navigation Properties

    //1 categoria tem vários Produtos
    public List<Product> Products { get; set; }

    #endregion

    public void ToUpdate(string description)
    { 
        Description = description;
    }
}

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A category description is required.")
            .MaximumLength(200).WithMessage("The category description should be a maximum of 200 characters.");

        RuleFor(x => x.DateRegistration)
            .NotEmpty().WithMessage("Registration is mandatory.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The registration date cannot be in the future.");
    }
}

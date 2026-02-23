using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.DomainServices.Services;
using Moq;

namespace CleanArchitecture.Tests;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _mockRepository;
    private readonly CategoryService _service;

    public CategoryServiceTests()
    {
        _mockRepository = new Mock<ICategoryRepository>();
        _service = new CategoryService(_mockRepository.Object);
    }

    [Fact(DisplayName = "Add_Exception")]
    public async Task Add_MustLaunchExcecao_WhenCategoryJaExists()
    {
        // Arrange
        var category = new Category() { Description = "Eletronics" };
        _mockRepository.Setup(r => r.GetByName(category.Description))
            .ReturnsAsync(category);

        // Act                        
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.Add(category));

        // Assert
        Assert.Equal("A category with that description already exists in the database.", exception.Message);
    }

    [Fact(DisplayName = "Add_MustAdd_WhenItDoesNotExist")]
    public async Task Add_Category_Should_Add_When_It_Does_Not_Exist()
    {
        // Arrange
        var category = new Category() { Description = "Eletronics" };
        _mockRepository.Setup(r => r.GetByName(category.Description))
            .ReturnsAsync((Category)null);

        // Act
        await _service.Add(category);

        // Assert
        _mockRepository.Verify(r => r.Add(category), Times.Once);
    }

    [Fact(DisplayName = "Update_Exception")]
    public async Task Update_ShouldThrowException_WhenCategoryDoesNotExist()
    {
        // Arrange
        var category = new Category() { IdCategory = 1, Description = "Livros" };
        _mockRepository.Setup(r => r.GetById(category.IdCategory))
            .ReturnsAsync((Category)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.ToUpdate(category));
        Assert.Equal("Category not found", exception.Message);
    }

    [Fact(DisplayName = "Update_ShouldAdd_WhenItDoesNotExist")]
    public async Task Update_MustUpdateCategory_WhenItExists()
    {
        // Arrange
        var categoryExisting = new Category { IdCategory = 1, Description = "Games" };
        var newCategory = new Category { IdCategory = 1, Description = "Consoles" };

        _mockRepository.Setup(r => r.GetById(newCategory.IdCategory))
            .ReturnsAsync(categoryExisting);

        // Act
        await _service.ToUpdate(newCategory);

        // Assert
        _mockRepository.Verify(r => r.ToUpdate(categoryExisting), Times.Once);
    }

    [Fact(DisplayName = "Exclude_ThrowException")]
    public async Task Remove_DeveLancarExcecao_NãoCategoriaNaoExist()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync((Category)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.Remove(1));
        Assert.Equal("Category not found", exception.Message);
    }

    [Fact(DisplayName = "Remove_MustDelete_WhenItExists")]
    public async Task Remove_MustDeleteCategory_WhenItExists()
    {
        // Arrange
        var category = new Category { IdCategory = 1, Description = "Esportes" };
        _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync(category);

        // Act
        await _service.Remove(1);

        // Assert
        _mockRepository.Verify(r => r.Remove(1), Times.Once);
    }

    [Fact(DisplayName = "GetById_ShouldReturnCategory_WhenExists")]
    public async Task GetById_ShouldReturnCategory_WhenExists()
    {
        // Arrange
        var category = new Category { IdCategory = 1, Description = "Casa" };
        _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync(category);

        // Act
        var result = await _service.GetById(1);

        // Assert
        Assert.Equal(category, result);
    }

    [Fact(DisplayName = "GetById_ShouldReturnNull_WhenItDoesNotExist")]
    public async Task GetById_ShouldReturnNull_WhenItDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetById(1)).ReturnsAsync((Category)null);

        // Act
        var result = await _service.GetById(1);

        // Assert
        Assert.Null(result);
    }

    [Fact(DisplayName = "GetAll")]
    public async Task GetAll_ShouldReturnListOfCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category { IdCategory = 1, Description = "Moda" },
            new Category { IdCategory = 2, Description = "Alimentos" }
        };
        _mockRepository.Setup(r => r.GetAll()).ReturnsAsync(categories);

        // Act
        var result = await _service.GetAll();

        // Assert
        Assert.Equal(2, result.Count());
    }
}
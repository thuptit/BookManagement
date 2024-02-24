using System.Net;
using BookManagement.API.Controllers;
using BookManagement.API.Test.Setup;
using BookManagement.Application.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static NUnit.Framework.Assert;

namespace BookManagement.API.Test;

[TestFixture]
public class CategoryControllerTest : ControllerFixture
{
    private readonly CategoryController _categoryController;
    public CategoryControllerTest()
    {
        _categoryController = new CategoryController(Resolve<IMediator>() ?? throw new InvalidOperationException());
    }
    [Test]
    public async Task Should_be_created_category()
    {
        //Arrange
        var command = new CreateCategoryCommand("Test", "Test");
        //Action
        var result = await _categoryController.Create(command);
        //Assert
        That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var category = await Context.Categories.FirstOrDefaultAsync(_ => _.Name == command.name);
        That(category, Is.Not.Null);
        That(category?.Name, Is.EqualTo(command.name));
    }
}
using System.Net;
using BookManagement.API.Controllers;
using BookManagement.API.Test.Setup;
using BookManagement.Application.Commands;
using BookManagement.Domain.Entities;
using BookManagement.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static NUnit.Framework.Assert;

namespace BookManagement.API.Test;

[TestFixture]
public class BookControllerTest : ControllerFixture
{
    private readonly BookController _bookController;
    public BookControllerTest()
    {
        _bookController = new BookController(Resolve<IMediator>() ?? throw new InvalidOperationException());
    }
    [Test]
    public async Task Should_be_created_book()
    {
        //Arrange
        var command = new CreateBookCommand("Test", "Test",null);
        //Action
        var result = await _bookController.Create(command);
        //Assert
        That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var book = await Context.Books.FirstOrDefaultAsync(_ => _.Name == command.name);
        That(book, Is.Not.Null);
    }

    [Test]
    public async Task Should_be_updated_book()
    {
        //Arrange
        var entityEntry = await Context.Books.AddAsync(new Book()
        {
            Name = "Update Test",
            Description = "Update Test"
        });
        await Context.SaveChangesAsync();
        var command = new UpdateBookCommand(entityEntry.Entity.Id, "Update Test 2", "Update Test 2", null);
        
        //Action
        var response = await _bookController.Update(command);
        
        //Assert
        That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var book = await Context.Books.FirstOrDefaultAsync(_ => _.Id == command.id);
        That(book, Is.Not.Null);
        That(book?.Name, Is.EqualTo(command.name));
    }
}
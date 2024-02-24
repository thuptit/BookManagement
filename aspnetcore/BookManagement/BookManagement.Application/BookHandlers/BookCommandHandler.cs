using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Application.Commands;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories.Book;
using BookManagement.Shared.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.BookHandlers
{
    public class BookCommandHandler(IBookRepository bookRepository) 
        : IRequestHandler<CreateBookCommand, ServiceResponse>,
            IRequestHandler<UpdateBookCommand, ServiceResponse>,
            IRequestHandler<DeleteBookCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await bookRepository.InsertAsync(new Book()
                {
                    Name = request.name,
                    Description = request.description,
                    CategoryId = request.categoryId
                });

                return new OkResponse();
            }
            catch (Exception e)
            {
                return new FailResponse(e.Message);
            }
        }

        public async Task<ServiceResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await bookRepository.GetAll().FirstOrDefaultAsync(_ => _.Id == request.id, cancellationToken);
                if (book is null)
                    return new FailResponse("Book is not found!");
                book.Name = request.name;
                book.Description = request.description;
                book.CategoryId = request.categoryId;

                await bookRepository.UpdateAsync(book);

                return new OkResponse();
            }
            catch (Exception e)
            {
                return new FailResponse(e.Message);
            }
        }

        public async Task<ServiceResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await bookRepository.GetAll().FirstOrDefaultAsync(_ => _.Id == request.id, cancellationToken);
                if (book is null)
                    return new FailResponse("Book is not found!");
                
                await bookRepository.DeleteAsync(book);

                return new OkResponse();
            }
            catch (Exception e)
            {
                return new FailResponse(e.Message);
            }
        }
    }
}

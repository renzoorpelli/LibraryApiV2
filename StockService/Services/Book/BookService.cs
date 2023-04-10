using AutoMapper;
using StockService.Infrastructure.Data.Repositories;
using StockService.Infrastructure.Data.UnitOfWork;
using BookDomain = StockService.Domain.Entities.Book;
using FluentValidation;
using StockService.Validation.Book;
using StockService.Infrastructure.Data.Repositories.Generic;
using OneOf;
using OneOf.Types;
using StockService.Domain.Entities;
using StockService.Validation;

namespace StockService.Services.Book;

public class BookService : IBookService
{
    //TODO VERFICIAR METODOS ASINCRONOS 
    private readonly IRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly BookRequestValidator _bookValidator;
    private readonly IMapper _mappper;

    public BookService(BookRepository repository,
        IUnitOfWork unitOfWork,
        BookRequestValidator bookValidator,
        IMapper mappper)
    {
        this._repository = repository;
        this._unitOfWork = unitOfWork;
        this._bookValidator = bookValidator;
        this._mappper = mappper;
    }


    public async Task<OneOf<Success, ValidationFailed>> Create(BookDomain book)
    {
        var validationResult = await _bookValidator.ValidateAsync(book);
        if(!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        _repository.Create(book);
        _unitOfWork.Commit();

        return new Success();
    }

    public async Task<OneOf<BookDomain, NotFound, ValidationFailed>> Update(BookDomain book, int idBook)
    {
        var validationResult = await _bookValidator.ValidateAsync(book);
        
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        if (!_repository.Check(idBook))
        {
            return new NotFound();
        }

        _repository.Update(book, idBook);
        _unitOfWork.Commit();

        return book;

    }

    public OneOf<Success, NotFound> Delete(int bookId)
    {
        if (!_repository.Check(bookId))
        {
            return new NotFound();
        }
        _repository.Delete(bookId);
        return new Success();
    }
}
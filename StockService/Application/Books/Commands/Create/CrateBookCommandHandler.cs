using AutoMapper;
using MediatR;
using OneOf;
using OneOf.Types;
using StockService.Domain.Entities;
using StockService.Services.Book;
using StockService.Validation;

namespace StockService.Application.Books.Commands.Create
{
    public class CrateBookCommandHandler : IRequestHandler<CreateBookCommand ,OneOf<Success, ValidationFailed>>
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public CrateBookCommandHandler(IBookService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public Task<OneOf<Success, ValidationFailed>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookMapped = _mapper.Map<Book>(request);
           
            return _service.Create(bookMapped);
        }
    }
}

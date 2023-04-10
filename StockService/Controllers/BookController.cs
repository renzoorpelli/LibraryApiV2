using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockService.Application.Books.Commands.Create;
using StockService.Application.Books.Commands.Delete;
using StockService.Application.Books.Commands.Update;
using StockService.Application.Books.Querys.GetAll;
using StockService.Services.Book;

namespace StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;

        public BookController(ISender sender)
        {
            this._sender = sender;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBooksQueryResponse>>> Get(long cursor, int pageSize)
        {
            return Ok(await _sender.Send(new GetBooksQuery() 
            { 
                Cursor = cursor, 
                PageSize = pageSize}
            ));
        }

        [HttpPost]
        public async Task<IActionResult>Create(CreateBookCommand command)
        {
             var result = await _sender.Send(command);

            return result.Match<IActionResult>(
            _ => CreatedAtAction(nameof(Get), new { mensaje = "Book Succesfly created." }),
            failed => BadRequest(failed));
        }


        //[HttpPut]
        //public async Task<IActionResult> Update([FromRoute] int id, 
        //    [FromBody] UpdateBookCommand updateBookCommand)
        //{
        //    return await _sender.Send(id, updateBookCommand);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    return await _sender.Send(new DeleteBookCommand() { Id = id});
        //}
    }
}

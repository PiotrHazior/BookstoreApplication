using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] BookDto bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(bookCreate);

            if (!_bookRepository.CreateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int bookId, [FromBody] BookDto updatedBook)
        {
            if (updatedBook == null)
                return BadRequest(ModelState);

            if (bookId != updatedBook.Id)
                return BadRequest(ModelState);

            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var bookMap = _mapper.Map<Book>(updatedBook);

            if (!_bookRepository.UpdateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong updating book");
                return StatusCode(500, ModelState);
            }

            return NoContent();
            
        }

        [HttpDelete("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var bookToDelete = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_bookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting book");
            }

            return NoContent();
        }

    }
}

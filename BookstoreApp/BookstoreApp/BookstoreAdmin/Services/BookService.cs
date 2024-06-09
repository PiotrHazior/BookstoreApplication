using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookstoreAdmin.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookService(IBookRepository bookRepository, IMapper mapper, DataContext context, ICategoryService categoryService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _context = context;
            _categoryService = categoryService;
        }
        public async Task<bool> CreateBookAsync(BookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            var categoryExists = await _context.Set<Category>().AnyAsync(c => c.Id == bookEntity.CategoryId);
            if (!categoryExists)
            {
                throw new InvalidOperationException("Invalid CategoryId");
            }

            var result = _bookRepository.CreateBook(bookEntity);
            return result;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = _bookRepository.GetBook(id);
            var result = _bookRepository.DeleteBook(book);
            return await Task.FromResult(result);
        }

        public async Task<BookDto> GetBookAsync(int id)
        {
            var book = _bookRepository.GetBook(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return await Task.FromResult(bookDto);
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = _bookRepository.GetBooks();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return await Task.FromResult(booksDto);
        }

        public async Task<bool> UpdateBookAsync(BookDto book)
        {
            var category = await _categoryService.GetCategoryAsync(book.CategoryId);
            if (category == null)
            {
                throw new InvalidOperationException("Invalid CategoryId");
            }

            var bookEntity = _mapper.Map<Book>(book);
            var categoryExists = await _context.Set<Category>().AnyAsync(c => c.Id == bookEntity.CategoryId);
            if (!categoryExists)
            {
                throw new InvalidOperationException("Invalid CategoryId");
            }

            var result = _bookRepository.UpdateBook(bookEntity);
            return await Task.FromResult(result);
        }
    }
}

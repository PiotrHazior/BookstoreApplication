using Application.Dto;
using AutoMapper;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public IndexModel(IBookService bookService, IMapper mapper, ICategoryService categoryService, ICustomerService customerService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _categoryService = categoryService;
            _customerService = customerService;
        }

        public IList<BookDto> Books { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public IList<CustomerDto> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Books = (await _bookService.GetBooksAsync()).ToList();
            Categories = (await _categoryService.GetCategoriesAsync()).ToList();
            Customers = (await _customerService.GetCustomersAsync()).ToList();
        }
    }
}

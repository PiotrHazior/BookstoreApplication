using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.User.Book
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookService _bookService;

        [BindProperty]
        public BookDto Book { get; set; }

        [BindProperty]
        public int CategoryId { get; set; }

        public CreateBookModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Book.CategoryId = CategoryId;

            var success = await _bookService.CreateBookAsync(Book);
            if (success)
            {
                return RedirectToPage("/User/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to create book.");
            return Page();
        }
    }
}

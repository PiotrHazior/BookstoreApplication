using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin.Book
{
    public class DeleteModel : PageModel
    {
        private readonly IBookService _bookService;

        public DeleteModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public BookDto Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _bookService.GetBookAsync(id);
            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (success)
            {
                return RedirectToPage("/Admin/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to delete book.");
            return Page();
        }
    }
}

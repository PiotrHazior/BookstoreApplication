using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BookstoreAdmin.Pages.Admin.Book
{
    public class UpdateModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public UpdateModel(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public BookDto Book { get; set; }
        public IList<CategoryDto> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _bookService.GetBookAsync(id);
            if (Book == null)
            {
                return NotFound();
            }

            Categories = (await _categoryService.GetCategoriesAsync()).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = (await _categoryService.GetCategoriesAsync()).ToList();
                return Page();
            }

            var success = await _bookService.UpdateBookAsync(Book);
            if (success)
            {
                return RedirectToPage("/Admin/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to update book.");
            Categories = (await _categoryService.GetCategoriesAsync()).ToList();
            return Page();
        }
    }
}

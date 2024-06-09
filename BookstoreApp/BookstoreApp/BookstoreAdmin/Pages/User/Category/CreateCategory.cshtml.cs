using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.User.Category
{
    public class CreateCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public CategoryDto Category { get; set; }

        public CreateCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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

            var success = await _categoryService.CreateCategoryAsync(Category);
            if (success)
            {
                return RedirectToPage("/User/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to create category.");
            return Page();
        }
    }
}

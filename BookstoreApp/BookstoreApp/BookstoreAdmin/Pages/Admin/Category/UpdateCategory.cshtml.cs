using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin.Category
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public CategoryDto Category { get; set; }

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _categoryService.GetCategoryAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryService.UpdateCategoryAsync(Category);

            return RedirectToPage("/Admin/Index");
        }
    }
}

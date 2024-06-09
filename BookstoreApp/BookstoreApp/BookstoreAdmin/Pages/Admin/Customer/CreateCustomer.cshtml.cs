using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin.Customer
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public CreateModel(ICustomerService customerService)
        {
            _customerService = customerService;
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

            var success = await _customerService.CreateCustomerAsync(Customer);
            if (success)
            {
                return RedirectToPage("/Admin/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to create customer.");
            return Page();
        }
    }
}

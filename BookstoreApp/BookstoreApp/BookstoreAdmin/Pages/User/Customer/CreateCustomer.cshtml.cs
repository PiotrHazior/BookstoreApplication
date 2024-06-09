using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.User.Customer
{
    public class CreateCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public CreateCustomerModel(ICustomerService customerService)
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
                return RedirectToPage("/User/Index");
            }

            ModelState.AddModelError(string.Empty, "Unable to create customer.");
            return Page();
        }
    }
}

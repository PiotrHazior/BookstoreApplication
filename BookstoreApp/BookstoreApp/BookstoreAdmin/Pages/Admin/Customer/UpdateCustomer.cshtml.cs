using Application.Dto;
using BookstoreAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin.Customer
{
    public class UpdateModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public UpdateModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _customerService.GetCustomerAsync(id);
            if (Customer == null)
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

            await _customerService.UpdateCustomerAsync(Customer);

            return RedirectToPage("/Admin/Index");
        }
    }
}

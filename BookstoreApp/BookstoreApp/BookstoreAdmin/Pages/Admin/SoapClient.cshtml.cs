using BookstoreSoapService.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookstoreAdmin.Pages.Admin
{
    public class SoapClientModel : PageModel
    {

        private readonly IBookSoapService _soapService;

        public SoapClientModel(IBookSoapService soapService)
        {
            _soapService = soapService;
        }

        public IList<Domain.Entities.Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            var books = await _soapService.GetBooksAsync();
            Books = books.ToList();
        }

    }
}

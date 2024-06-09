using System;
using System.Threading.Tasks;
using BookServiceReference;
using CategoryServiceReference;
using CustomerServiceReference;

namespace BookstoreSoapClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            IBookSoapService bookServiceChannel = new BookSoapServiceClient(BookSoapServiceClient.EndpointConfiguration.BasicHttpBinding_IBookSoapService);
            ICategorySoapService categoryServiceChannel = new CategorySoapServiceClient(CategorySoapServiceClient.EndpointConfiguration.BasicHttpBinding_ICategorySoapService);
            ICustomerSoapService customerServiceChannel = new CustomerSoapServiceClient(CustomerSoapServiceClient.EndpointConfiguration.BasicHttpBinding_ICustomerSoapService);


            try
            {
                // Book

                var newBook = new BookServiceReference.Book()
                {
                    Title = "Atomowe Nawyki",
                    Author = "J. Clear",
                    ISBN = "99764373",
                    Price = 15.00M
                };

                var createBookResponse = await bookServiceChannel.CreateBookAsync(0, newBook);
                Console.WriteLine($"Book created: {createBookResponse}");

                newBook = new BookServiceReference.Book()
                {
                    Title = "Bastion",
                    Author = "S.King",
                    ISBN = "95757573",
                    Price = 20.00M
                };

                createBookResponse = await bookServiceChannel.CreateBookAsync(0, newBook);
                Console.WriteLine($"Book created: {createBookResponse}");


                var books = await bookServiceChannel.GetBooksAsync();

                Console.WriteLine("Lista książek:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Price: {book.Price}");
                }



                // Category
                var newCategory = new CategoryServiceReference.Category()
                {
                    Name = "Horror"
                };

                var createCategoryResponse = await categoryServiceChannel.CreateCategoryAsync(newCategory);
                Console.WriteLine($"Category created: {createCategoryResponse}");

                var categories = await categoryServiceChannel.GetCategoriesAsync();

                Console.WriteLine("Lista kategorii:");
                foreach (var category in categories)
                {
                    Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
                }



                // Customer
                var newCustomer = new CustomerServiceReference.Customer()
                {
                    FirstName = "Ewa",
                    LastName = "Kowalska",
                    Email = "ekowalska@example.com"
                }; 

                var createCustomerResponse = await customerServiceChannel.CreateCustomerAsync(newCustomer);
                Console.WriteLine($"Customer created: {createCustomerResponse}");

                var customers = await customerServiceChannel.GetCustomersAsync();

                Console.WriteLine("Lista klientów:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Id: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}, Email: {customer.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

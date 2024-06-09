using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Seed
{
    public static async Task SeedDataContext(DataContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Apply any pending migrations
        await context.Database.MigrateAsync();

        // Seed roles
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        // Seed admin user
        if (await userManager.FindByEmailAsync("admin@example.com") == null)
        {
            var adminUser = new IdentityUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com"
            };

            var result = await userManager.CreateAsync(adminUser, "AdminPassword123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Seed regular user
        if (await userManager.FindByEmailAsync("user@example.com") == null)
        {
            var regularUser = new IdentityUser
            {
                UserName = "user@example.com",
                Email = "user@example.com"
            };

            var result = await userManager.CreateAsync(regularUser, "UserPassword123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(regularUser, "User");
            }
        }

        // Seed initial data if necessary
        if (!await context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Fantasy" },
                new Category { Name = "Science Fiction" },
                new Category { Name = "Literatura Faktu" }
            };
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }

        if (!await context.Customers.AnyAsync())
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            };
            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }

        if (!await context.Books.AnyAsync())
        {
            var categories = await context.Categories.ToListAsync();
            var books = new List<Book>
            {
                new Book { Title = "Harry Potter i Kamień Filozoficzny", Author = "J.K. Rowling", ISBN = "9992942194", CategoryId = categories[0].Id, Price = 15.00M },
                new Book { Title = "Metro 2033", Author = "Dmitry Glukhovsky", ISBN = "999293424", CategoryId = categories[1].Id, Price = 20.00M },
                new Book { Title = "Ostatnie życzenie. Wiedźmin. Tom 1", Author = "Andrzej Sapkowski", ISBN = "9992942342", CategoryId = categories[0].Id, Price = 15.00M },
                new Book { Title = "Krwawy kobalt", Author = "Kara Siddhart", ISBN = "9992523412", CategoryId = categories[2].Id, Price = 30.00M },
                new Book { Title = "Liczby nie kłamią", Author = "Vaclav Smil", ISBN = "9992424234", CategoryId = categories[2].Id, Price = 35.00M }
            };
            context.Books.AddRange(books);
            await context.SaveChangesAsync();
        }

        if (!await context.Orders.AnyAsync())
        {
            var customers = await context.Customers.ToListAsync();
            var orders = new List<Order>
            {
                new Order { CustomerId = customers[0].Id, OrderDate = new DateTime(2024, 1, 31), TotalAmount = 30.00M },
                new Order { CustomerId = customers[1].Id, OrderDate = new DateTime(2023, 1, 1), TotalAmount = 15.00M },
                new Order { CustomerId = customers[0].Id, OrderDate = new DateTime(2024, 2, 15), TotalAmount = 35.00M },
                new Order { CustomerId = customers[1].Id, OrderDate = new DateTime(2024, 12, 1), TotalAmount = 30.00M }
            };
            context.Orders.AddRange(orders);
            await context.SaveChangesAsync();
        }

        if (!await context.OrderBooks.AnyAsync())
        {
            var orders = await context.Orders.ToListAsync();
            var books = await context.Books.ToListAsync();
            var orderBooks = new List<OrderBook>
            {
                new OrderBook { OrderId = orders[0].Id, BookId = books[3].Id },
                new OrderBook { OrderId = orders[1].Id, BookId = books[0].Id },
                new OrderBook { OrderId = orders[2].Id, BookId = books[4].Id },
                new OrderBook { OrderId = orders[3].Id, BookId = books[3].Id }
            };
            context.OrderBooks.AddRange(orderBooks);
            await context.SaveChangesAsync();
        }
    }
}

using Application.Interfaces;
using Application.Mapper;
using BookstoreSoapService.Interfaces;
using BookstoreSoapService.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<IBookSoapService, BookSoapService>();
builder.Services.AddSingleton<ICategorySoapService, CategorySoapService>();
builder.Services.AddSingleton<ICustomerSoapService, CustomerSoapService>();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add SOAP services
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.UseSoapEndpoint<IBookSoapService>("/BookSoapService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
    endpoints.UseSoapEndpoint<ICategorySoapService>("/CategorySoapService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
    endpoints.UseSoapEndpoint<ICustomerSoapService>("/CustomerSoapService.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Run();

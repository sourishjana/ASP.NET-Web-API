using BookStore.API.Repository;
using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.API.Helpers;

//--------------------------------------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// added cors:
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",policy =>
    {
         policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// added connection string and Context class
builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB"));
});

// added Dependency Injection for Controllers
builder.Services.AddTransient<IBookRepository, BookRepository>();

// adding automapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// .AddNewtonsoftJson() is added extra for PATCH request
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//--------------------------------------------------------------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy"); // cors added

app.UseAuthorization();

app.MapControllers();

app.Run();

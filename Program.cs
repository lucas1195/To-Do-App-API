using Microsoft.EntityFrameworkCore;
using System.Globalization;
using todo_API.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer
    ("Data Source=Lucas;Initial Catalog=ToDo;Integrated Security=True;Trust Server Certificate=True"));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

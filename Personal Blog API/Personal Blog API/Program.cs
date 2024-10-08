using Microsoft.EntityFrameworkCore;
using Personal_Blog_API.Data;
using Personal_Blog_API.Repositorues;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbCnotext>(options =>
               options.UseSqlServer(
               builder.Configuration.GetConnectionString("MyConnection")
               ));


builder.Services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

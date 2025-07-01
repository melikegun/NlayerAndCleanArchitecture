using App.Repositories.Extensions;
using App.Services;
using App.Services.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FluentValidationFilter>();
    // FluentValidation kullan�rken, null referans hatalar�n� �nlemek i�in bu ayar� yap�yoruz.
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Bu sat�r, API'nin model do�rulama hatalar�n� otomatik olarak ele almas�n� devre d��� b�rak�r.
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extension method(AddRepositoies) kullanmak, program�n Program.cs k�sm�n� temiz ve d�zenli tutar.
builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);

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

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
    // FluentValidation kullanýrken, null referans hatalarýný önlemek için bu ayarý yapýyoruz.
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Bu satýr, API'nin model doðrulama hatalarýný otomatik olarak ele almasýný devre dýþý býrakýr.
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extension method(AddRepositoies) kullanmak, programýn Program.cs kýsmýný temiz ve düzenli tutar.
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

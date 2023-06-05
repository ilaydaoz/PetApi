using FluentValidation.AspNetCore;
using Pet.Core.Application;
using Pet.Core.Application.Validation.User;
using Pet.Infrastructure;
using Shared.Pet.Middleware;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .AddFluentValidation(opt =>
     {
    opt.RegisterValidatorsFromAssemblyContaining<InsertRegistrationValidator>();
    opt.DisableDataAnnotationsValidation = true;
    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSingleton<JWTAuthenticationMiddleware>();

var app = builder.Build();

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

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

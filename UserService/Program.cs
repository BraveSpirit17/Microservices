using FluentValidation;
using FluentValidation.AspNetCore;
using UserApi;
using UserApi.Repositories;
using UserApi.Services;
using UserApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<UserContext>();

// Add services to the container.
builder.Services.AddScoped<IUserRepository, SQLiteUserRepository>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
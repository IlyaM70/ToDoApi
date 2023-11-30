using Microsoft.EntityFrameworkCore;
using System;
using ToDoApi;
using ToDoApi.Data;
using ToDoApi.Data.Repositories;
using ToDoApi.Data.Repositories.RepositoryInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(builder
    .Configuration.GetConnectionString("MsSqlConnection"))
    );
builder.Services.AddScoped<IToDoRepository,ToDoRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

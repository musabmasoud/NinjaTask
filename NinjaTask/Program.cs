using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Data;
using Application.Interfaces;
using Infrastructure.Services;
using Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NinjaDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISegmentService, SegmentService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

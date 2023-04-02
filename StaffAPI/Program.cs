using Microsoft.EntityFrameworkCore;
using StaffAPI.Data;
using StaffAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring Services
builder.Services.AddTransient<IStaffRepository, StaffRepository>();

builder.Services.AddDbContext<StaffAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffAPIConnectionString")));

// Adding The Automapper
builder.Services.AddAutoMapper(typeof(Program));

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

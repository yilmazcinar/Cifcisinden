using Cifcisinden.Data.Context;
using Cifcisinden.Data.Repositories;
using Cifcisinden.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CifcisindenDbContext>(options => options.UseSqlServer(cs));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//Generic olduðu için typeof kullanýldý.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();






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

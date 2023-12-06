using AltiusHubTestData;
using AltiusHubTestRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AltiusHubDbContext>(options => options.UseSqlServer
(
    builder.Configuration.GetConnectionString("AltiusHubDB")
    ));

builder.Services.AddScoped<DbContext, AltiusHubDbContext>();
builder.Services.AddScoped<IRepository,Repository>();

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

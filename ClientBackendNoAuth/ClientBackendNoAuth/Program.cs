using ClientBackendNoAuth.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MxchaziContext>(options =>
        options.UseNpgsql("Server=localhost;search path=core;Port=5432;Database=mxchazi;User Id=postgres;Password=123;"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Does not work with nextjs, highly requested feature. see https://stackoverflow.com/questions/70440486/locally-developing-nextjs-and-fetch-getting-self-signed-cert-error?rq=1
//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

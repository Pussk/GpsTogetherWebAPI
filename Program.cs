using Microsoft.EntityFrameworkCore;
using GpsTogetherWebAPI.Data;
using GpsTogetherWebAPI.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=GpsTogetherDb;User Id=sa;Password=Strong!Pass123;TrustServerCertificate=True"));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true); // permite qualquer origem (como 127.0.0.1:5500)
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<LocationHub>("/locationhub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

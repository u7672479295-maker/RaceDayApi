using Microsoft.EntityFrameworkCore;
using RaceDayApi.Data;

var builder = WebApplication.CreateBuilder(args);


//now we are going to register RaceDayContext with SQL Server
builder.Services.AddDbContext<RaceDayContext>(options =>


options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if  (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "RaceDay API v1");
            options.RoutePrefix = string.Empty;
        }

    );

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();



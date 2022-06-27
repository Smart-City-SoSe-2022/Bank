using bankbackend;
using bankbackend.BackgroundServices;
using EasyNetQ;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.





builder.Services.AddCors(o => o.AddPolicy("MyAllowSpecificOrigins", builder =>
{
    builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials();
}));

builder.Services.AddControllers();






try
{
    string rabbitmqcon = "host=10.104.41.215;username=bank;password=Cp4iupK5detH5E7;timeout=60";
    var bus = RabbitHutch.CreateBus(rabbitmqcon);
    builder.Services.AddSingleton(bus);
    builder.Services.AddHostedService<UserEventHandler>();
}
catch { }   // Ignore if RabbitMQ is not running
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

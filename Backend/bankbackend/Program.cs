using bankbackend.BackgroundServices;
using bankbackend.Models;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EasyNetQ;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();


string rabbitmqcon = "host=host.docker.internal;username=guest;password=guest;timeout=60";
var bus = RabbitHutch.CreateBus(rabbitmqcon);
builder.Services.AddSingleton(bus);
builder.Services.AddHostedService<UserEventHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

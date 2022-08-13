using System;
using System.Reflection;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(c => {
    var entryAssembly = Assembly.GetEntryAssembly();

    c.AddConsumers(entryAssembly);

    c.UsingRabbitMq((c,b) => {
        b.Host("localhost", h => {});
        b.ConfigureEndpoints(c);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

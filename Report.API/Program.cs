using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.Extensions.Options;
using Shared;
using System.Reflection;
using Report.API.Consumers;
using Report.API.Services;
using Report.API.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddFluentValidation(v =>
{
    v.ImplicitlyValidateChildProperties = true;
    v.ImplicitlyValidateRootCollectionElements = true;
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<PersonContactCreatedEventConsumer>();
    config.AddConsumer<ReportCreatedEventConsumer>();
    config.UsingRabbitMq((context, _config) =>
    {
        _config.Host(new Uri(builder.Configuration["RabbitMq"]));
        _config.ReceiveEndpoint(RabbitMQSettings.ReportCreatedEventQueue, x => x.ConfigureConsumer<PersonContactCreatedEventConsumer>(context));
        _config.ReceiveEndpoint(RabbitMQSettings.ReportCreateEventQueue, x => x.ConfigureConsumer<ReportCreatedEventConsumer>(context));
    });
});


builder.Services.AddScoped<IPersonContactService, PersonContactService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportDetailService, ReportDetailService>();

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

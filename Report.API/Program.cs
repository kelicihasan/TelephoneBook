using MassTransit;
using Report.API.Consumers;
using Report.Application.Services.Abstract;
using Report.Persistence.Services;
using Shared;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using Contact.Application.Repositories;
using Contact.Application.Repositories.Abstract;
using Contact.Application.Services;
using Contact.Persistence.Context;
using Contact.Persistence.Repositories;
using Contact.Persistence.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddTransient<IContactService, ContactService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ContactDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("MyWebApiConection")));



builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((context, _config) =>
    {
        _config.Host(builder.Configuration.GetSection("RabbitMq")["HostName"]);
        _config.UseCircuitBreaker(configurator =>
        {
            configurator.TrackingPeriod = TimeSpan.FromMinutes(1);
            configurator.TripThreshold = 15;
            configurator.ActiveThreshold = 10;
            configurator.ResetInterval = TimeSpan.FromMinutes(5);
        });
    });
});

builder.Services.AddAutoMapper(typeof(Contact.Application.Mapping.MappingProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IContactService, ContactService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

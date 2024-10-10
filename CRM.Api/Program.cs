using System.Reflection;
using Common;
using Common.Config;
using CRM.Api.Consummers;
using CRM.Api.CQRS;
using CRM.Api.Model;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Get<AppSettings>();

builder.Services.AddDbContext<CrmDbContext>(options 
    => options.UseSqlServer(AppSettings.ConnectionStrings.EsoftCRM));

builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PricingAgreementConsumer>();
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(AppSettings.ServiceBus.ConnectionString);

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddScoped<ICQRSClient, CQRSClient>();
builder.Services.AddScoped<IPIMClient, PIMClient>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();

app.MapControllers();

app.Run();
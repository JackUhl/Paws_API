using Paws_API.DomainLayer.Config;
using Paws_API.DomainLayer.Config.Container;
using Paws_API.DomainLayer.Handlers.PetfinderHandler;
using Paws_API.InfrastructureLayer.Service.PetfinderService;
using Paws_API.InfrastructureLayer.Service.PetfinderService.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdoptablePetsHandler, AdoptablePetsHandler>();
builder.Services.AddScoped<IPetfinderHttpClient, PetfinderHttpClient>();
builder.Services.AddScoped<IPetfinderService, PetfinderService>();

builder.Services.Configure<PetfinderServiceSettings>(builder.Configuration.GetSection("PetfinderService"));

builder.Services.AddSingleton<IConfigurationContainer, ConfigurationContainer>();

builder.Services.AddHttpClient();

var allowedOriginsPolicy = "AllowedOrigins";
var allowedOriginsSettings = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOriginsPolicy, builder =>
    {
        builder.WithOrigins(allowedOriginsSettings);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedOriginsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

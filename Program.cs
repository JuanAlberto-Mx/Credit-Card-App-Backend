using credit_card_app_backend;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Binding the startup file to recognize the configurations made
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

// Builds the swagger HTML page
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "credit-card-app-backend"));
app.MapControllers();
app.Run();
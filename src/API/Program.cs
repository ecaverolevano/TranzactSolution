using Tranzact.Premium.Api.Middleware;
using Tranzact.Premium.Application;
using Tranzact.Premium.Persistence;
using Tranzact.Premium.Persistence.Extention;
using Tranzact.Premium.Persistence.DatabaseContext;
using Tranzact.Premium.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<PremiumDatabaseContext>();
    dbContext.SeedData();
}

app.UseCors(options => options.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

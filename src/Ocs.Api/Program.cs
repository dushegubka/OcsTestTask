using System.Text.Json.Serialization;
using Ocs.Api.ExceptionHandlers;
using Ocs.Api.Extensions;
using Ocs.ApplicationLayer.Extensions;
using Ocs.Infrastructure;
using Ocs.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x => {
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddNpgsql<ApplicationDbContext>(
    builder.Configuration.GetConnectionString("Ocs"));

// Add infrastructure
builder.Services.AddInfrastructure();

// Add app services 
builder.Services.AddAppServices();

// Add exception handlers
builder.Services.AddExceptionHandlers();

var app = builder.Build();

app.UseExceptionHandler((_ => {}));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

//app.UseHttpsRedirection();
app.Run();

using Microsoft.AspNetCore.Mvc;
using NLog;
using Services.Contracts;
using webAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);





Console.WriteLine(String.Concat(Directory.GetCurrentDirectory(), "nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "/nlog.config"));


builder.Services.AddControllers(conf =>
{
    conf.RespectBrowserAcceptHeader = true; // içerik pazarlýðýna açýðýz
    conf.ReturnHttpNotAcceptable = true; // Kabul etmediðimiz içerikler için geriye dönüt bilgi veriyoruz 406 NotAcceptable

})
.AddCostumCsvFormatter()
.AddXmlDataContractSerializerFormatters()
.AddApplicationPart(typeof(Presentations.AssemblyReference).Assembly);

builder.Services.Configure<ApiBehaviorOptions>(conf =>
conf.SuppressModelStateInvalidFilter = true
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();

builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


if (app.Environment.IsProduction())
{
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

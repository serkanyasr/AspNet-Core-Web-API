
using NLog;
using webAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);





Console.WriteLine(String.Concat(Directory.GetCurrentDirectory(), "nlog.config"));
LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "/nlog.config"));


builder.Services.AddControllers().AddApplicationPart(typeof(Presentations.AssemblyReference).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

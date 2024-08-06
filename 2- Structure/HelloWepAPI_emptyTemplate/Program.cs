
var builder = WebApplication.CreateBuilder(args);


//Servis kayýtlarý burada yapýlýyor.

builder.Services.AddControllers();  // Controller servis kaydý
builder.Services.AddEndpointsApiExplorer(); // EndPointleri yakalamasý için ekledik (/home , /main, /main/home/index)
builder.Services.AddSwaggerGen(); // Nuget paket yöneticisinden indirilip servis kayýtlarýna ekleme yapýldý

var app  = builder.Build(); // Servis kayýtlarýnýn yaptýktan sonra Build iþlemini yapýyoruz


/// Devolopment ve Production yapýsýna göre istediðimiz durumlara göre congigure edbibiliriz.
if (app.Environment.IsDevelopment()) 
{

    app.UseSwagger();  // Uygulamayý build ettikten sonra servislerin kullanýlmasý için Use dememiz lazým
    app.UseSwaggerUI();

}

app.MapControllers(); // Controller da belrlediðimiz EndPointleri app görebilmesi için kullanmalýyýz
app.Run();


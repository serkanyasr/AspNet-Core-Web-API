
var builder = WebApplication.CreateBuilder(args);


//Servis kay�tlar� burada yap�l�yor.

builder.Services.AddControllers();  // Controller servis kayd�
builder.Services.AddEndpointsApiExplorer(); // EndPointleri yakalamas� i�in ekledik (/home , /main, /main/home/index)
builder.Services.AddSwaggerGen(); // Nuget paket y�neticisinden indirilip servis kay�tlar�na ekleme yap�ld�

var app  = builder.Build(); // Servis kay�tlar�n�n yapt�ktan sonra Build i�lemini yap�yoruz


/// Devolopment ve Production yap�s�na g�re istedi�imiz durumlara g�re congigure edbibiliriz.
if (app.Environment.IsDevelopment()) 
{

    app.UseSwagger();  // Uygulamay� build ettikten sonra servislerin kullan�lmas� i�in Use dememiz laz�m
    app.UseSwaggerUI();

}

app.MapControllers(); // Controller da belrledi�imiz EndPointleri app g�rebilmesi i�in kullanmal�y�z
app.Run();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
























/*Program.cs filen er startpunktet for en .NET applikasjon. Den setter opp og kjører applikasjonen. Hovedoppgavene er:

Bygge Appen: Setter opp konfigurasjonen.
Legge til Tjenester: Legger til nødvendige tjenester som kontrollere og API-dokumentasjon.
Kjøre Appen: Starter og kjører applikasjonen på serveren.
Denne filen sørger for at applikasjonen fungerer som den skal.*/
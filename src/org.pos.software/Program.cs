using org.pos.software.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n b�sica de servicios
builder.Services.AddControllers();

// Configuraciones modulares de servicios
SwaggerConfig.ConfigureServices(builder.Services);
DependencyInjection.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configuraci�n del middleware
MiddlewareConfig.Configure(app, builder.Configuration);

app.MapGet("/", () =>
{

    var currentTime = DateTime.Now.ToString("HH:mm:ss");

    return Results.Ok(new
    {
        message = "�API Funcionando!",
        time = currentTime,
        status = true
    });

});

app.Run();
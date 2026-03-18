using Backend.App.Modules.Producto.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
//Cors
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngular", policy => {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//Servicios de .NET
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Servicios del módulo Producto
ProductoUseCaseRegister.Register(builder.Services, builder.Configuration);
var app = builder.Build();
// --- 4. PIPELINE DE EJECUCIÓN ---
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAngular");
// Mapeamos los controladores que viven en Infraestructura/Adapters/Http
app.MapControllers(); 
app.Run();
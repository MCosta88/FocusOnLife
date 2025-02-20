using FocusOnLife.API.Configurations;
using FocusOnLife.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Registrar os serviços da aplicação
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("_myCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
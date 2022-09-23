using EenJaarGratis.Services.Handlers;
using EenJaarGratis.UI.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHub<SignalRHub>("/signalr");
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod()
        .SetIsOriginAllowed(_ => true);
});
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.Run();
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///builder.Services.AddDbContext<BdfrontendContext>(Options=> Options.UseMySQL(builder.Configuration.GetConnectionString("Mysql")!));
builder.Services.AddDbContext<Jq4bContext>(Options=> Options.UseMySQL(builder.Configuration.GetConnectionString("Mysql")!));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cors=> { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAlmacenamiento, AlmacenamientoLocal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;
using NeuroAssist.Data;
using NeuroAssist.Services;
using NeuroAssistWeb;
using NeuroAssistWeb.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPredictionEnginePool<TumorModel.ModelInput, TumorModel.ModelOutput>()
    .FromFile("TumorModel.mlnet");


// Add services to the container.
builder.Services.AddDbContext<MainDbContext>(options =>
              options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<BrainscanService>();
builder.Services.AddSingleton<UploadFileService>();
builder.Services.AddSingleton<GeminiService>();
builder.Services.AddSingleton<FileConverterService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

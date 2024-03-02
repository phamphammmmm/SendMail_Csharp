using Microsoft.AspNetCore.Builder;
using SendMail;
using SendMail.Service;
using SimpleEmailApp.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailService, EmailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerDocument(config =>
{
    config.DocumentName = "v1";
    config.PostProcess = document =>
    {
        document.Info.Title = "API Manage";
        document.Info.Version = "v1";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "PhamTienDat",
            Email = "Phamtiendat246@gmail.com"
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseOpenApi(config =>
{
    config.Path = "/swagger/v1/swagger.json";
});

app.UseSwaggerUi(config =>
{
    config.Path = "/api";
    config.DocumentPath = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

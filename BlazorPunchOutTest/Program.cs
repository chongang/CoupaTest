using BlazorPunchOutTest.Components;
using BlazorPunchOutTest.Controllers;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers().AddXmlSerializerFormatters(); // Add this line
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddScoped<CookieService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Ensure this is included
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

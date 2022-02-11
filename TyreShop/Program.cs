using Tyre.Data.Dbinitializer;
using TyreShop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
RegisterService.ConfigureApplicationServices(builder);
var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var DbInitializer = services.GetRequiredService<IDatabaseInitializer>();
    DbInitializer?.MigrateDbsAsync().Wait();
    DbInitializer?.SeedDataAsync().Wait();
}
//ServiceActivator.Configure(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

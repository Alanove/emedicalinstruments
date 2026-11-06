var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "/About",
        defaults: new { controller = "Pages", action = "About" });
app.MapControllerRoute(
        name: "default",
        pattern: "/Webminars",
        defaults: new { controller = "Pages", action = "Webminars" });
app.MapControllerRoute(
        name: "default",
        pattern: "/WhyUs",
        defaults: new { controller = "Pages", action = "WhyUs" });
app.MapControllerRoute(
        name: "default",
        pattern: "/Certified",
        defaults: new { controller = "Pages", action = "Certified" });
app.MapControllerRoute(
        name: "default",
        pattern: "/Services",
        defaults: new { controller = "Pages", action = "Services" });

app.MapControllerRoute(
        name: "default",
        pattern: "/Contact",
        defaults: new { controller = "Pages", action = "Contact" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

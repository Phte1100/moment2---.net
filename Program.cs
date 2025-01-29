var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //aktierar mvc
var app = builder.Build();

app.UseStaticFiles(); //aktiverar statiska filer, wwwroot
app.UseRouting(); //aktiverar routing

// routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    
app.Run();

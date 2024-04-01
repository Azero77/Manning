using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => 
    {
        opts.UseSqlServer(
            builder.Configuration["ConnectionStrings:SportsStoreConnection"]
            ) ;
    });

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped(srv => SessionCart.GetCart(srv));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!";
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute("Categories",
    "{category}/Page{PageNumber:int}",
    new { controller = "Home", action = "Index" });



app.MapControllerRoute("Pagination",
    "Page{PageNumber:int}",
    new { controller = "Home", action = "Index", PageNumber = 1 });

app.MapControllerRoute("CatPage",
    "{category}",
    new { controller = "Home", action = "Index", PageNumber = 1 });




app.MapControllerRoute("Products",
    "Products/Page{PageNumber:int}",
    new { controller = "Home", action = "Index" });

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapBlazorHub();
app.EnsureIsPopulated();
app.Run();

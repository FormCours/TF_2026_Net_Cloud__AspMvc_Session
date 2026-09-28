using Demo_ASPMVC_Session.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*
builder.Services.AddSingleton<DemoService>();  // Une seul et unique instance
builder.Services.AddScoped<DemoService>();     // Une instance par requete
builder.Services.AddTransient<DemoService>();  // Une nouvelle instance à chaque demande
*/
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<MemberService>();

// Add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

using System.Buffers.Text;

var builder = WebApplication.CreateBuilder(args);

//Add MVC Controller with Views
builder.Services.AddControllersWithViews();

//Register HttpClient to communicate with RaceDayApi
builder.Services.AddHttpClient("RaceDayApi", client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
        ?? "http://localhost:5081/api/";
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddTransient<RaceDayWeb.Services.ApiService>();

//Enable Session State for User Authentication & Roles
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
     app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
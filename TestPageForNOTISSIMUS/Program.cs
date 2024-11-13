using Microsoft.EntityFrameworkCore;
using  MsSQLDbConntext;

var builder = WebApplication.CreateBuilder(args);






// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultDBConnection");



builder.Services.AddDbContext<ProductsMsSqlDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(connection));


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


app.MapGet("/api/products", (ProductsMsSqlDbContext db) => db.Products.ToList());

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


using Microsoft.EntityFrameworkCore;
using SEYRÝ_ALA.Data; // Namespace'inde büyük Ý varsa böyle kalmalý

var builder = WebApplication.CreateBuilder(args);

// EF Core DbContext kaydý (ConnectionStrings:DefaultConnection'ý kullanýr)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

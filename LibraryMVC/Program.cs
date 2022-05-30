using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryMVC.Application;
using LibraryMVC.Application.ViewModel.Borrower;
using LibraryMVC.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*var connectionString = builder.Configuration.GetConnectionString("ContextConnection") ?? throw new InvalidOperationException("Connection string 'ContextConnection' not found.");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>(); ;
*/
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddTransient<IValidator<NewBorrowerVm>, NewBorrowerValidation>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;

    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
});
builder.Services.AddAuthentication().AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["ClientId"];
    options.ClientSecret = googleAuthNSection["ClientSecret"];
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanAddNewBorrower", policy =>
    policy.RequireClaim("ViewBorrowers", "AddNewBorrower"));
    options.AddPolicy("CanViewBorrowers", policy =>
    policy.RequireClaim("ViewBorrowers"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{*article}",
    defaults: new { controller = "Blog", action = "Action" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

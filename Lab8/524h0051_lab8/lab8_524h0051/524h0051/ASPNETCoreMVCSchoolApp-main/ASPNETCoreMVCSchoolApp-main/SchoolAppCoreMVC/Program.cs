using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
using SchoolAppCoreMVC.Services;

// Dung dau cham (.) cho so thap phan (vd: 3.5) bat ke may cai Region la gi
var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // can cho ReportViewer (.rdlc)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDBConnectionString")));

builder.Services.AddScoped<EnrollmentReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

using BLL.Service;
using DAL.Repository;
using System.Data.SqlClient;
using Tools.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Ajout de ma TookBOX

builder.Services.AddTransient<Connection>((service)=> 
{
    return new Connection(SqlClientFactory.Instance, builder.Configuration.GetConnectionString("Default"));

}); 
//Ajout de ma DAL
builder.Services.AddTransient<PatientRepository>();
builder.Services.AddTransient<PatientAllRepository>();

//AJOUT DE MA BLL
builder.Services.AddTransient<PatientService>();
builder.Services.AddTransient<PatientAllService>();





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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

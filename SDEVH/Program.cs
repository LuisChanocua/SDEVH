
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Errores perzonalidazados
app.UseExceptionHandler("/Error");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


#region RutasHome
app.MapControllerRoute(
        name: "ControlUsuarios",
        pattern: "ControlUsuarios",
        defaults: new { controller = "Home", action = "ControlUsuarios" });
#endregion

#region Errores
app.MapControllerRoute(
        name: "Error404",
        pattern: "Error404",
        defaults: new { controller = "Errores", action = "Error404" });

app.MapControllerRoute(
        name: "Error500",
        pattern: "Error500",
        defaults: new { controller = "Errores", action = "Error500" });



#endregion


#region Rutas Default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*Si no encuentra la ruta lo manda a 404*/
app.MapControllerRoute(
            name: "Error404",
            pattern: "{*url}",
            defaults: new { controller = "Errores", action = "Error404" });

#endregion


app.Run();

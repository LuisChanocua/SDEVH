using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SDEVH.Models;
using SDEVH.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*Conexion BD*/
builder.Services.AddDbContext<SdevhContext>(options =>
options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

#region Services
/*Declaramos servicio para poder usarlo en el proyecto*/
builder.Services.AddScoped<UserServices>();

#endregion

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

//Vistas enrutadas
#region RutasAccount
app.MapControllerRoute(
        name: "Login",
        pattern: "Login",
        defaults: new { controller = "Account", action = "Login" });

#endregion

#region RutasActasPosesion
app.MapControllerRoute(
        name: "CreacionActas",
        pattern: "ActaPosesion/CreacionActas",
        defaults: new { controller = "ActaPosesion", action = "GenerarActaPosesion" });

app.MapControllerRoute(
        name: "EditarActaPosesion",
        pattern: "ActaPosesion/EditarActaPosesion",
        defaults: new { controller = "ActaPosesion", action = "EditarActaPosesion" });

app.MapControllerRoute(
        name: "IngresarMedidas",
        pattern: "ActaPosesion/IngresarMedidas",
        defaults: new { controller = "ActaPosesion", action = "IngresarMedidasPosesion" });

app.MapControllerRoute(
        name: "IngresarMedidas",
        pattern: "ActaPosesion/SubirArchivos",
        defaults: new { controller = "ActaPosesion", action = "SubirArchivos" });

app.MapControllerRoute(
        name: "IngresarMedidas",
        pattern: "ActaPosesion/VistaPrevia",
        defaults: new { controller = "ActaPosesion", action = "VistaPreviaActaPosesion" });

#endregion

#region RutasHome
app.MapControllerRoute(
        name: "ControlUsuarios",
        pattern: "ControlUsuarios",
        defaults: new { controller = "Home", action = "ControlUsuarios" });

app.MapControllerRoute(
        name: "EstadoActa",
        pattern: "EstadoActa",
        defaults: new { controller = "Home", action = "EstadoActaPresidente" });

app.MapControllerRoute(
        name: "EncontrarTerreno",
        pattern: "EncontrarTerreno",
        defaults: new { controller = "Home", action = "EncontrarTerreno" });

app.MapControllerRoute(
        name: "DocumentosAbiertos",
        pattern: "DocumentosAbiertos",
        defaults: new { controller = "Home", action = "HomePresidente" });
#endregion

#region Apis
app.MapControllerRoute(
        name: "api/RegistrarUsuario",
        pattern: "api/RegistrarUsuario",
        defaults: new { controller = "Account", action = "RegistrarUsuario" });

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
    pattern: "/",
    defaults: new { controller = "Home", action = "Index" });


/*Si no encuentra la ruta lo manda a 404*/
app.MapControllerRoute(
            name: "Error404",
            pattern: "{*url}",
            defaults: new { controller = "Errores", action = "Error404" });

#endregion


app.Run();

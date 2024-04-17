using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
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
        name: "login",
        pattern: "login",
        defaults: new { controller = "Account", action = "Login" });

#endregion

#region RutasActasPosesion
app.MapControllerRoute(
        name: "creacionactas",
        pattern: "actaposesion/creacionactas",
        defaults: new { controller = "ActaPosesion", action = "GenerarActaPosesion" });

app.MapControllerRoute(
        name: "editaractaposesion",
        pattern: "actaPosesion/editaractaposesion",
        defaults: new { controller = "ActaPosesion", action = "EditarActaPosesion" });

app.MapControllerRoute(
        name: "actaposesion/ingresarmedidas",
        pattern: "actaposesion/ingresarmedidas",
        defaults: new { controller = "ActaPosesion", action = "IngresarMedidasPosesion" });

app.MapControllerRoute(
        name: "actaPosesion/subirarchivos",
        pattern: "actaPosesion/subirarchivos",
        defaults: new { controller = "ActaPosesion", action = "SubirArchivos" });

app.MapControllerRoute(
        name: "actaposesion/vistaprevia",
        pattern: "actaposesion/vistaprevia",
        defaults: new { controller = "ActaPosesion", action = "VistaPreviaActaPosesion" });

#endregion

#region RutasHome
app.MapControllerRoute(
        name: "controlusuarios",
        pattern: "controlusuarios",
        defaults: new { controller = "Home", action = "ControlUsuarios" });

app.MapControllerRoute(
        name: "estadoacta",
        pattern: "estadoacta",
        defaults: new { controller = "Home", action = "EstadoActaPresidente" });

app.MapControllerRoute(
        name: "encontrarterreno",
        pattern: "encontrarterreno",
        defaults: new { controller = "Home", action = "EncontrarTerreno" });

app.MapControllerRoute(
        name: "documentosabiertos",
        pattern: "documentosabiertos",
        defaults: new { controller = "Home", action = "HomePresidente" });

app.MapControllerRoute(
        name: "notificacionesdocumentos",
        pattern: "notificacionesdocumentos",
        defaults: new { controller = "Home", action = "NotificacionesActas" });

app.MapControllerRoute(
        name: "controlusuarios/editardatosusuario",
        pattern: "controlusuarios/editardatosusuario/{UsuarioId?}",
        defaults: new { controller = "Home", action = "EditarDatosUsusario" });

#endregion

#region Apis
app.MapControllerRoute(
        name: "api/registrarusuario",
        pattern: "api/registrarusuario",
        defaults: new { controller = "Account", action = "RegistrarUsuario" });

#endregion

#region Errores
app.MapControllerRoute(
        name: "error404",
        pattern: "error404",
        defaults: new { controller = "Errores", action = "Error404" });

app.MapControllerRoute(
        name: "error500",
        pattern: "error500",
        defaults: new { controller = "Errores", action = "Error500" });



#endregion

#region Rutas Default
app.MapControllerRoute(
    name: "default",
    pattern: "/",
    defaults: new { controller = "Home", action = "Index" });


/*Si no encuentra la ruta lo manda a 404*/
app.MapControllerRoute(
            name: "error404",
            pattern: "{*url}",
            defaults: new { controller = "Errores", action = "Error404" });

#endregion


app.Run();

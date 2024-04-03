$(document).ready(function () {
    $("#btn_anadir").click(function () {
        // Ocultar la alerta antes de realizar la validaci�n
        $("#alertas").hide();

        // Obtener los valores de los campos de entrada
        var norte = $("#norte").val();
        var sur = $("#sur").val();
        var este = $("#este").val();
        var oeste = $("#oeste").val();

        // Validar que los campos no est�n vac�os
        if (norte !== "" && sur !== "" && este !== "" && oeste !== "") {
            // Validar cualquier otra condici�n si es necesario
            // ...
            // Mostrar alerta si ocurre alg�n error
            // $("#alertas").show();
            // $("#alertas").text("Error: mensaje de error aqu�");
        } else {
            // Mostrar alerta si no se completan todos los campos
            $("#alertas").show();
            $("#alertas").text("Asegurese de llenar todos los campos.");
        }
    });
});

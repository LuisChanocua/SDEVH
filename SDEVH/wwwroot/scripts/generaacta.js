$(document).ready(function () {
    $("#btn_anadir").click(function () {
        // Ocultar la alerta antes de realizar la validaci�n
        $("#alertas").hide();

        // Obtener los valores de los campos de entrada
        var tipo = $("#tipo").val();
        var nombre = $("#nombre").val();
        var sede = $("#sede").val();

        // Validar que los campos no est�n vac�os
        if (tipo !== "" && nombre !== "" && sede !== "") {
            if (!validarCorreo(nombre)) {
                //correo invalido
                console.log("Complete los datos")
                return false;
            }
            if (!validarTelefono(sede)) {
                //tel invalido
                console.log("Complete los datos")
                return false;
            }

        } else {
            $("#alertas").show();
            $("#alertas").text("Aseg�rese de llenar todos los campos.");
        }
    });
});

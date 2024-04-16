$("#btn_anadir").click(function () {
    // Ocultar la alerta antes de realizar la validación
    $("#alertas").hide();

    // Obtener los valores de los campos de entrada
    var tipo = $("#tipo").val();
    var nombre = $("#nombre").val();
    var sede = $("#sede").val();

    // Validar que los campos no estén vacíos
    if (tipo !== "" && nombre !== "" && sede !== "") {
        if (!validarNombre(nombre)) {
            //correo invalido
            console.log("Complete los datos")
            return false;
        }
        if (!validarSede(sede)) {
            //tel invalido
            console.log("Complete los datos")
            return false;
        }

    } else {
        $("#alertas").show();
        $("#alertas").text("Asegurese de llenar todos los campos.");
    }
});



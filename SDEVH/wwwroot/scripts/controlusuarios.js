$("#btn_anadir").click(function () {
    $("#alertas").hide();


    /*Tomamos las variables de los campos para validar */
    var nombre = $("#nombre").val();
    var correo = $("#correo").val();
    var tel = $("#tel").val();
    var contrasena = $("#contrasena").val();
    var apellidos = $("#apellidos").val();
    var direccion = $("#direccion").val();
    var cargo = $("#cargo").val();




    /*Validaciones de los campos no estén vacios*/
    if (nombre = ! "" && correo != "" && tel != "" && contrasena != "" && apellidos != "" && direccion != "" && cargo != "") {

        if (!validarCorreo(correo)) {
            //correo invalido
            console.log("Correo invalido")
            return false;
        }
        if (!validarTelefono(tel)) {
            //tel invalido
            console.log("Tel invalido")
            return false;
        }

    } else {
        $("#alertas").show();
        $("#alertas").text("Asegurese de llenar todos los campos");

    }

});



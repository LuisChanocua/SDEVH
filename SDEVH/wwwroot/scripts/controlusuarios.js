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
    if (nombre != "" && correo != "" && tel != "" && contrasena != "" && apellidos != "" && direccion != "" && cargo != "") {
        
        if (!validarCorreo(correo)) {
            //correo invalido
            showModalErrores("Correo invalido")
            return false;
        }
        if (!validarTelefono(tel)) {
            //tel invalido
            showModalErrores("Tel invalido")
            return false;
        }

        //Llamada ajax al registro del usuario
        var dataUsuario = {
            Nombre: nombre,
            Apellidos: apellidos,
            Direccion: direccion,
            Correo: correo,
            Password: contrasena,
            Cargo: cargo,
            Tel: tel
        };

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/api/RegistrarUsuario',
            type: 'POST',
            data: dataUsuario,
            success: function (data) {
                // Manejar la respuesta exitosa
                if (data.success) {
                    console.log("Usuario Registrado")
                    window.location.href = "/ControlUsuarios";
                }
                              
            },
            error: function (xhr, status, error) {
                // Manejar errores

            }
        });


    } else {
        showModalErrores("Asegurese de llenar todos los campos");

    }

});






$("#btn_anadir").click(function () {
    $("#alertas").hide();


    /*Tomamos las variables de los campos para validar */
    var nombre = $("#nombre").val().trim();
    var correo = $("#correo").val().trim();
    var tel = $("#tel").val().trim();
    var contrasena = $("#contrasena").val().trim();
    var apellidos = $("#apellidos").val().trim();
    var direccion = $("#direccion").val().trim();
    var cargo = $("#cargo").val().trim();




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

//Actualizar Usuario
$("#btn_actualizar").click(function () {
    /*Tomamos las variables de los campos para validar */
    var nombre = $("#nombre").val().trim();
    var correo = $("#correo").val().trim();
    var tel = $("#tel").val().trim();
    var apellidos = $("#apellidos").val().trim();
    var direccion = $("#direccion").val().trim();
    var cargo = $("#cargo").val().trim();




    /*Validaciones de los campos no estén vacios*/
    if (nombre != ""  && correo != "" && tel != "" && apellidos != "" && direccion != "" && cargo != "") {

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
        console.log(nombre);
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

        //// Realizar la solicitud AJAX
        //$.ajax({
        //    url: '/api/RegistrarUsuario',
        //    type: 'POST',
        //    data: dataUsuario,
        //    success: function (data) {
        //        // Manejar la respuesta exitosa
        //        if (data.success) {
        //            console.log("Usuario Registrado")
        //            window.location.href = "/ControlUsuarios";
        //        }

        //    },
        //    error: function (xhr, status, error) {
        //        // Manejar errores

        //    }
        //});


    } else {
        showModalErrores("Asegurese de llenar todos los campos");

    }
});




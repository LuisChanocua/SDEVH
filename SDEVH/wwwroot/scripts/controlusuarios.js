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




    /*Validaciones de los campos no est�n vacios*/
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

        //Llamada ajax al registro del usuario
        // Objeto de datos que incluye el valor float
        var dataSend = {

        };

        let dataUserForm = new FormData;

        dataUserForm.append("Nombre", nombre);
        dataUserForm.append("Apellidos", apellidos);
        dataUserForm.append("Direccion", direccion);
        dataUserForm.append("Correo", correo);
        dataUserForm.append("Password", contrasena);
        dataUserForm.append("Cargo", cargo);
        dataUserForm.append("Tel", tel);


        // Realizar la solicitud AJAX
        $.ajax({
            url: 'api/RegistrarUsuario',
            type: 'POST',
            data: dataUserForm,
            success: function (response) {
                // Manejar la respuesta exitosa
                if (dataUserForm.success) {
                    console.log(dataUserForm.message);
                    // Redirecciona si la llamda es exitosa
                    window.location.href = "/ControlUsuarios";
                }                
            },
            error: function (xhr, status, error) {
                // Manejar errores

            }
        });


    } else {
        $("#modalErrores").show();
        $("#mensaje_modal_errores").text("Asegurese de llenar todos los campos");

    }

});



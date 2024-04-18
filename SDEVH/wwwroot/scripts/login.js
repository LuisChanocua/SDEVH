document.addEventListener("DOMContentLoaded", function () {
    const btnIngresar = document.getElementById("btn_ingresar");
    const inputCorreo = document.getElementById("correo");
    const inputContrasena = document.getElementById("contrasena");
    const modalErrores = document.getElementById("modalErrores");
    const mensaje_modal_errores = document.getElementById("mensaje_modal_errores");

    

    //function mostrarModalErrores(mensaje) {
    //    mensaje_modal_errores.textContent = mensaje;
    //    modalErrores.style.display = "block";
    //}

    //function cerrarModalErrores() {
    //    modalErrores.style.display = "none";
    //}

    function validarCorreo(correo) {
        const patronCorreo = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return patronCorreo.test(correo);
    }

    function validarContrasena(contrasena) {
        return contrasena.length >= 6;
    }

    function validarCampos() {
        const correo = inputCorreo.value.trim();
        const contrasena = inputContrasena.value.trim();

        if (correo === '' || contrasena === '') {
            showModalErrores("Por favor, complete todos los campos.");
            return false;
        }

        if (!validarCorreo(correo)) {
            showModalErrores("Por favor, ingrese un correo electrónico válido.");
            return false;
        }

        if (!validarContrasena(contrasena)) {
            showModalErrores("La contraseña debe tener al menos 6 caracteres.");
            return false;
        }

        //showModalErrores("¡Bienvenido! Has iniciado sesión correctamente.");
        return true;
    }

    btnIngresar.addEventListener("click", function () {
        var correo = $("#correo").val().trim();
        var contrasena = $("#contrasena").val().trim();
        
        if (correo != "" && contrasena != "") {

            if (!validarCorreo(correo)) {
                //correo invalido
                showModalErrores("Correo invalido")
                return false;
            }

            var dataUsuario = {
                correo: $("#correo").val().trim(),
                password: $("#contrasena").val().trim()
            }

            // Realizar la solicitud AJAX
            $.ajax({
                url: '/api/iniciarsesion',
                type: 'POST',
                data: dataUsuario,
                success: function (data) {
                    // Manejar la respuesta exitosa
                    if (data.success) {
                        console.log("Iniciado sesion")
                        window.location.href = "/";
                    } else {
                        showModalErrores(data.message);
                    }

                },
                error: function (xhr, status, error) {
                    showModalErrores("Error: " + error);

                }
            });
        } else {
            showModalErrores("Asegurese de llenar todos los campos")
        }
    });

    //document.getElementById("cerrar_modal_errores").addEventListener("click", function () {
    //    cerrarModalErrores();
    //});

    //window.addEventListener("click", function (event) {
    //    if (event.target == modalErrores) {
    //        cerrarModalErrores();
    //    }
    //});
});

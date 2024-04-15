document.addEventListener("DOMContentLoaded", function () {
    const btnIngresar = document.getElementById("btn_ingresar");
    const inputCorreo = document.getElementById("correo");
    const inputContrasena = document.getElementById("contrasena");
    const modalErrores = document.getElementById("modalErrores");
    const mensaje_modal_errores = document.getElementById("mensaje_modal_errores");

    function mostrarModalErrores(mensaje) {
        mensaje_modal_errores.textContent = mensaje;
        modalErrores.style.display = "block";
    }

    function cerrarModalErrores() {
        modalErrores.style.display = "none";
    }

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
            mostrarModalErrores("Por favor, complete todos los campos.");
            return false;
        }

        if (!validarCorreo(correo)) {
            mostrarModalErrores("Por favor, ingrese un correo electrónico válido.");
            return false;
        }

        if (!validarContrasena(contrasena)) {
            mostrarModalErrores("La contraseña debe tener al menos 6 caracteres.");
            return false;
        }

        mostrarModalErrores("¡Bienvenido! Has iniciado sesión correctamente.");
        return true;
    }

    btnIngresar.addEventListener("click", function () {
        validarCampos();
    });

    document.getElementById("cerrar_modal_errores").addEventListener("click", function () {
        cerrarModalErrores();
    });

    window.addEventListener("click", function (event) {
        if (event.target == modalErrores) {
            cerrarModalErrores();
        }
    });
});

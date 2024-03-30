document.addEventListener("DOMContentLoaded", function () {
    const btnIngresar = document.getElementById("btn_ingresar");
    const inputCorreo = document.getElementById("correo");
    const inputContrasena = document.getElementById("contrasena");
    const modal = document.getElementById("modal");
    const mensajeModal = document.getElementById("mensaje_modal");

    function mostrarModal(mensaje) {
        mensajeModal.textContent = mensaje;
        modal.style.display = "block";
    }

    function cerrarModal() {
        modal.style.display = "none";
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
            mostrarModal("Por favor, complete todos los campos.");
            return false;
        }

        if (!validarCorreo(correo)) {
            mostrarModal("Por favor, ingrese un correo electrónico válido.");
            return false;
        }

        if (!validarContrasena(contrasena)) {
            mostrarModal("La contraseña debe tener al menos 6 caracteres.");
            return false;
        }

        mostrarModal("¡Bienvenido! Has iniciado sesión correctamente.");
        return true;
    }

    btnIngresar.addEventListener("click", function () {
        validarCampos();
    });

    document.getElementById("cerrar_modal").addEventListener("click", function () {
        cerrarModal();
    });

    window.addEventListener("click", function (event) {
        if (event.target == modal) {
            cerrarModal();
        }
    });
});

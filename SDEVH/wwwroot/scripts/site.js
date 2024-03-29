/*Contiene funciones que se pueden usar en todo el proyecto */
/*Metodo que valida el correo*/
function validarCorreo(correo) {
    // Expresión regular para validar el formato del correo electrónico
    var expresionCorreo = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Verificar si el correo cumple con el formato
    if (expresionCorreo.test(correo)) {
        return true; // El correo es válido
    } else {
        return false; // El correo no es válido
    }
}

/*ValidarTelefono*/
function validarTelefono(telefono) {
    // Expresión regular para validar el formato del número de teléfono
    var expresionTelefono = /^\d{10}$/;

    // Verificar si el número de teléfono cumple con el formato
    if (expresionTelefono.test(telefono)) {
        return true; // El número de teléfono es válido
    } else {
        return false; // El número de teléfono no es válido
    }
}
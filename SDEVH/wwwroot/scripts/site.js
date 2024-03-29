/*Contiene funciones que se pueden usar en todo el proyecto */
/*Metodo que valida el correo*/
function validarCorreo(correo) {
    // Expresi�n regular para validar el formato del correo electr�nico
    var expresionCorreo = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Verificar si el correo cumple con el formato
    if (expresionCorreo.test(correo)) {
        return true; // El correo es v�lido
    } else {
        return false; // El correo no es v�lido
    }
}

/*ValidarTelefono*/
function validarTelefono(telefono) {
    // Expresi�n regular para validar el formato del n�mero de tel�fono
    var expresionTelefono = /^\d{10}$/;

    // Verificar si el n�mero de tel�fono cumple con el formato
    if (expresionTelefono.test(telefono)) {
        return true; // El n�mero de tel�fono es v�lido
    } else {
        return false; // El n�mero de tel�fono no es v�lido
    }
}
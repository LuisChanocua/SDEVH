$("#btn_anadir").click(function () {
    $("#alertas").hide();

    // Tomamos las variables de los campos para validar
    var norte = $("#norte").val();
    var sur = $("#sur").val();
    var este = $("#este").val();
    var oeste = $("#oeste").val();
    var norte2 = $("#norte2").val(); // Corregido: utiliza norte2 en lugar de norte
    var sur2 = $("#sur2").val(); // Corregido: utiliza sur2 en lugar de sur
    var este2 = $("#este2").val(); // Corregido: utiliza este2 en lugar de este
    var oeste2 = $("#oeste2").val(); // Corregido: utiliza oeste2 en lugar de oeste

    // Validaciones de los campos no estén vacíos
    if (norte !== "" && sur !== "" && este !== "" && oeste !== "" &&
        norte2 !== "" && sur2 !== "" && este2 !== "" && oeste2 !== "") {

        if (!validarNorte(norte) || !validarCorreo(norte2)) {
            // Correo inválido
            console.log("Numero inválido");
            return false;
        }
        if (!validarSur(sur) || !validarTelefono(sur2)) {
            // Teléfono inválido
            console.log("Numero inválido");
            return false;
        }
        if (!validarEste(este) || !validarTelefono(este2)) {
            // Teléfono inválido
            console.log("Numero inválido");
            return false;
        }
        if (!validarOeste(oeste) || !validarTelefono(oeste2)) {
            // Teléfono inválido
            console.log("Numero inválido");
            return false;
        }

    } else {
        $("#alertas").show();
        $("#alertas").text("Asegúrese de llenar todos los campos");
    }
});

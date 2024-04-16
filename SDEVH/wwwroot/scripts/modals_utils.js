/*Modales errores logica */
var ModalsResources = {
    msgError: "Mensaje de error"

}

function showModalErrores(msgerror) {
    $("#cerrar_modal_errores").show();
    $("#mensaje_modal_errores").text(msgerror);

}




//cierra el modal de errores
$("#cerrar_modal_errores").click(function () {
    $("#modalErrores").hide();
});
let t1 = gsap.timeline();
let t2 = gsap.timeline();
let t3 = gsap.timeline();

t1.to(".cog1",
{
    transformOrigin: "50% 50%",
    rotation: "+=360",
    repeat: -1,
    ease: Linear.easeNone,
    duration: 8
});

t2.to(".cog2",
{
    transformOrigin: "50% 50%",
    rotation: "-=360",
    repeat: -1,
    ease: Linear.easeNone,
    duration: 8
});

t3.fromTo(".wrong-para",
{
    opacity: 0
},
{
    opacity: 1,
    duration: 1,
    stagger: {
    repeat: -1,
    yoyo: true
    }
});


function actualizarEtiquetas() {
    if (window.matchMedia("(max-width: 768px)").matches) {
        // Eliminar etiquetas existentes
        var primerNumero = document.querySelector('.first-four');
        var segundoNumero = document.querySelector('.cog-wheel1');
        var tercerNumero = document.querySelector('.cog-wheel2');
        var cuartoNumero = document.querySelector('.second-four');
        var contenedor = document.querySelector('.container');
        var valorError = document.querySelector('.numeroError');

        if (primerNumero) {
            contenedor.removeChild(primerNumero);
        }
        if (segundoNumero) {
            contenedor.removeChild(segundoNumero);
        }
        if (tercerNumero) {
            contenedor.removeChild(tercerNumero);
        }
        if (cuartoNumero) {
            contenedor.removeChild(cuartoNumero);
        }

        if (valorError !== null) {
            contenedor.removeChild(valorError);
        }

        // Crear y agregar nuevas etiquetas
        var nuevaEtiqueta = document.createElement("h1");
        nuevaEtiqueta.className = "numeroError";
        nuevaEtiqueta.textContent = "404";

        contenedor.appendChild(nuevaEtiqueta);
    }
}

// Llamar a la función cuando la página se carga y cuando la ventana cambia de tamaño
window.onload = actualizarEtiquetas;
window.onresize = actualizarEtiquetas;


let t1 = gsap.timeline();
let t2 = gsap.timeline();
let t3 = gsap.timeline();
let contador = 0;

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
    if (window.matchMedia("(max-width: 1059px)").matches) {
        // Eliminar etiquetas existentes
        var primerNumero = document.querySelector('.first-four');
        var segundoNumero = document.querySelector('.cog-wheel1');
        var tercerNumero = document.querySelector('.cog-wheel2');
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

        if (valorError !== null) {
            contenedor.removeChild(valorError);
        }

        contador++;

        // Crear y agregar nuevas etiquetas
        var nuevaEtiqueta = document.createElement("h1");
        nuevaEtiqueta.className = "numeroError";
        nuevaEtiqueta.textContent = "500";

        contenedor.appendChild(nuevaEtiqueta);
    } else if (window.matchMedia("(min-width: 1060px)").matches) {
        if (contador > 0) {
            var contenedor = document.querySelector('.container');
            var valorError = document.querySelector('.numeroError');
            var mensaje = document.querySelector('.wrong-para');
            if (valorError !== null) {
                contenedor.removeChild(valorError);
            }
            if (mensaje !== null) {
                contenedor.removeChild(mensaje);
            }

            contenedor.innerHTML = `
                <h1 class="first-four">5</h1>
                <div class="cog-wheel1">
                    <div class="cog1">
                        <div class="top"></div>
                        <div class="down"></div>
                        <div class="left-top"></div>
                        <div class="left-down"></div>
                        <div class="right-top"></div>
                        <div class="right-down"></div>
                        <div class="left"></div>
                        <div class="right"></div>
                    </div>
                </div>
                <div class="cog-wheel2">
                    <div class="cog2">
                        <div class="top"></div>
                        <div class="down"></div>
                        <div class="left-top"></div>
                        <div class="left-down"></div>
                        <div class="right-top"></div>
                        <div class="right-down"></div>
                        <div class="left"></div>
                        <div class="right"></div>
                    </div>
                </div>
                <p class="wrong-para">Error Interno del Servidor :(</p>
            `;
        }

    }
}

// Llamar a la función cuando la página se carga y cuando la ventana cambia de tamaño
window.onload = actualizarEtiquetas;
window.onresize = actualizarEtiquetas;

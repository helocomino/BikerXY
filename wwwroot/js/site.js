document.addEventListener('DOMContentLoaded', function () {

    // Configuración del componente Toast de Bootstrap
    const toastElement = document.getElementById('toast-carrito');
    let toastBootstrap = null;
    if (toastElement) {
        toastBootstrap = new bootstrap.Toast(toastElement, { delay: 3500 }); // Dura 3.5 segundos en pantalla
    }

    // Función auxiliar para lanzar la notificación flotante
    function mostrarNotificacion(mensaje, esExito = true) {
        const txtMensaje = document.getElementById('toast-mensaje');
        const iconoMensaje = document.getElementById('toast-icono');

        if (txtMensaje && toastElement && toastBootstrap) {
            txtMensaje.innerText = mensaje;

            if (esExito) {
                toastElement.className = "toast align-items-center text-white bg-dark border-0 shadow-lg";
                iconoMensaje.innerText = "🏍️";
            } else {
                toastElement.className = "toast align-items-center text-white bg-danger border-0 shadow-lg";
                iconoMensaje.innerText = "⚠️";
            }

            toastBootstrap.show();
        }
    }

    // Buscar todos los botones de agregar al carrito
    const botonesCarrito = document.querySelectorAll('.btn-agregar-carrito');

    botonesCarrito.forEach(boton => {
        boton.addEventListener('click', function (e) {
            e.preventDefault();

            // Validar si el usuario está logeado de forma visual
            const estaLogeado = this.getAttribute('data-logeado') === 'true';

            if (!estaLogeado) {
                mostrarNotificacion("Para agregar productos al carrito, debes iniciar sesión o crear una cuenta.", false);
                setTimeout(() => {
                    window.location.href = '/Account/Login';
                }, 1500); // Espera un segundo y medio para que el usuario logre leer la notificación antes de redirigir
                return;
            }

            const motoId = this.getAttribute('data-id');
            const formData = new FormData();
            formData.append('motoId', motoId);

            fetch('/Cart/AddToCart', {
                method: 'POST',
                body: formData
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        const contadorCarrito = document.getElementById('cuenta-carrito');
                        if (contadorCarrito) {
                            contadorCarrito.innerText = data.totalItems;
                        }
                        // 🎉 NOTIFICACIÓN VISUAL FLOTANTE EXITOSA
                        mostrarNotificacion("¡Excelente elección! Moto añadida al carrito.");
                    } else {
                        // 🚨 NOTIFICACIÓN VISUAL FLOTANTE DE ERROR (Sin stock)
                        mostrarNotificacion(data.message, false);
                    }
                })
                .catch(error => {
                    console.error("Error al agregar al carrito:", error);
                    mostrarNotificacion("Hubo un error al procesar la solicitud.", false);
                });
        });
    });
});
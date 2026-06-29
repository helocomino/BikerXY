// Manejador del evento cuando se hace clic en "Agregar al carrito"
document.addEventListener('DOMContentLoaded', function () {

    // Buscar todos los botones de agregar al carrito en la página
    const botonesCarrito = document.querySelectorAll('.btn-agregar-carrito');

    botonesCarrito.forEach(boton => {
        boton.addEventListener('click', function (e) {
            e.preventDefault();

            // 1️⃣ VALIDADOR DE CUENTA: Revisamos la etiqueta que configuramos en el HTML
            const estaLogeado = this.getAttribute('data-logeado') === 'true';

            if (!estaLogeado) {
                // Si no inició sesión, soltamos la alerta y lo frenamos
                alert("⚠️ Para agregar productos al carrito, debes iniciar sesión o crear una cuenta.");

                // Lo redirigimos automáticamente a la pantalla de Login
                window.location.href = '/Account/Login';
                return; // Detiene la ejecución por completo
            }

            // 2️⃣ LÓGICA DEL CARRITO (Solo se ejecuta si está logeado):
            // Obtenemos el ID de la moto desde el atributo data-id
            const motoId = this.getAttribute('data-id');

            // Buscamos el elemento de texto que dice "0" en el menú superior
            const contadorCarrito = document.getElementById('cuenta-carrito');

            if (contadorCarrito) {
                // Sumamos 1 al número actual del carrito de forma visual
                let cantidadActual = parseInt(contadorCarrito.innerText) || 0;
                contadorCarrito.innerText = cantidadActual + 1;

                // Alerta visual de éxito
                alert("🏍️ ¡Excelente elección! Moto agregada al carrito.");
            }
        });
    });
});
document.addEventListener('DOMContentLoaded', function () {

    // Buscar todos los botones de agregar al carrito
    const botonesCarrito = document.querySelectorAll('.btn-agregar-carrito');

    botonesCarrito.forEach(boton => {
        boton.addEventListener('click', function (e) {
            e.preventDefault();

            // 1️⃣ Validar si el usuario está logeado de forma visual
            const estaLogeado = this.getAttribute('data-logeado') === 'true';

            if (!estaLogeado) {
                alert("⚠️ Para agregar productos al carrito, debes iniciar sesión o crear una cuenta.");
                window.location.href = '/Account/Login';
                return;
            }

            // 2️⃣ Obtener los datos del botón
            const motoId = this.getAttribute('data-id');

            // 3️⃣ ENVIAR EL PRODUCTO AL SERVIDOR (A la acción AddToCart del CartController)
            // Usamos FormData para empaquetar el ID de la moto de forma limpia
            const formData = new FormData();
            formData.append('motoId', motoId);

            fetch('/Cart/AddToCart', {
                method: 'POST',
                body: formData
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // Actualizamos el contador del menú superior con el número real que devuelve el servidor
                        const contadorCarrito = document.getElementById('cuenta-carrito');
                        if (contadorCarrito) {
                            contadorCarrito.innerText = data.totalItems;
                        }
                        alert("🏍️ ¡Excelente elección! Moto agregada al carrito.");
                    } else {
                        // Si el servidor detecta que se acabó el stock, te frena aquí y muestra el aviso
                        alert("⚠️ " + data.message);
                    }
                })
                .catch(error => {
                    console.error("Error al agregar al carrito:", error);
                    alert("Hubo un error al procesar la solicitud.");
                });
        });
    });
});
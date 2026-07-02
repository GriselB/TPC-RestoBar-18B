document.addEventListener('DOMContentLoaded', function () {

    var hfMostrarModal = document.querySelector('.hf-mostrar-modal');
    if (hfMostrarModal && hfMostrarModal.value === '1') {
        var modalElement = document.getElementById('modalConfirmarPedido');
        if (modalElement) {
            var modal = new bootstrap.Modal(modalElement);
            modal.show();
        }
    }

});
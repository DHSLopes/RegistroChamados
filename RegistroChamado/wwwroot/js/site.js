// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function preencheColaborador(lstSetorCtrl, lstColaboradorId) {
    var lstColaboradores = $(lstColaboradorId);
    lstColaboradores.empty();

    var setorSelecionado = lstSetorCtrl.options[lstSetorCtrl.selectedIndex].value;

    if (setorSelecionado != null && setorSelecionado != '') {
        $.getJSON("/chamado/GetColaboradorPorSetor", { SetorId: setorSelecionado }, function (colaboradores) {
            if (colaboradores != null && !jQuery.isEmptyObject(colaboradores)) {
                $.each(colaboradores, function (index, colab) {
                    lstColaboradores.append($('<option/>', {
                        value: colab.value,
                        text: colab.text
                    }));
                });
            };
        });
    }
    return;
}
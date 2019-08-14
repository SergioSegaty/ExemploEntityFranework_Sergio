
$(function () {

    $("#computador-pecas-index").DataTable({

        ajax: "/computadorpeca/obtertodos?idComputador=" + $idComputador,
        serverSide: true,
        columns:
            [
                { data: "peca.Nome" },
                { data: "peca.Preco" },
                {
                    render: function (data, type, row) {
                        return "\
                <button class='btn btn-secondary botao-editar '\
                data-id="+ row.id +"> Apagar </button>";
                    }
                }

            ]
    });



})
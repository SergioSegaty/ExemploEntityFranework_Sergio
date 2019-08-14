$(function () {

    $("#computador-index").DataTable({
        ajax: '/computador/obtertodos',
        serverSide: true,
        columns:
            [
                { data: 'id' },
                { data: 'categoria.nome' },
                { data: 'nome' },
                { data: 'preco' },
                {
                    render: function (type, data, row) {
                        return "\
                        <a href='/computador/editar?id="+ row.id + "'\
                        class='btn btn-primary'> Editar </a>\
                        <button data-id='"+ row.id +"' \
                        class='btn btn-danger botao-apagar'>Apagar</button>";
                    }
                }

            ]

    })

})
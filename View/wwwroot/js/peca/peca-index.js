$idAlterar = -1;

$(function () {

    $('#modal-peca-salvar').on('click', function () {
        $nome = $('#modal-peca-nome').val();

        if ($idAlterar == -1) {
            inserir($nome);
        } else {
            alterar($nome);
        }

    });

    function inserir($nome) {
        $.ajax({

            url: '/peca/inserir',
            method: 'post',
            data: { nome: $nome },
            success: function (data) {
                $('#modal-peca-cadastro').modal('hide');
                $tabelaPecas.ajax.reload();
            },
            error: function (err) { console.log(err) }
        });
    }

    function alterar($nome) {
        $.ajax({

            url: '/peca/alterar',
            method: 'post',
            data: { id: $idAlterar, nome: $nome },
            success: function (data) {
                $('#modal-peca-cadastro').modal('hide');
                $idAlterar = -1;
                $tabelaPecas.ajax.reload();
            },
            err: function (err) {
                console.log(err);
            }
        })
    }

    $('.table').on('click', '.botao-editar', function () {
        $idAlterar = $(this).data('id');
        $.ajax({

            url: 'peca/obterpeloid?id=' + $idAlterar,
            method: 'get',
            success: function (data) {
                $('#modal-peca-nome').val(data.nome);
                $('#modal-peca-cadastro').modal('show');
                $('#modal-peca-nome').focus();
            },

            error: function (err) { console.log(err); }
        })

    });

    $('.table').on('click', '.botao-apagar', function () {

        $id = $(this).data('id');
        $.ajax({

            url: 'peca/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                $tabelaPecas.ajax.reload();
            },
            error: function (err) {
                console.log(err);
            }
        })

    });

    $tabelaPecas = $('#peca-index').DataTable({

        ajax: '/peca/obtertodos',
        serverSide: true,
        columns: [
            { data: 'id' },
            { data: 'nome' },
            {
                render: function (data, type, row) {
                    return "\
                    <button class='btn btn-primary botao-editar' \
                    data-id='" + row.id + "'>Editar</button>\
                    <button class='btn btn-danger botao-apagar' \
                    data-id='" + row.id + "'>Apagar</button>";
                }
            }
        ]
    })
});
$(function () {
    $idPutz = -1;

    $tabelaCategoria = $('#categoria-index').DataTable({
        ajax: 'https://localhost:5001/categoria/obtertodos',
        serverSide: true,
        columns: [
            { data: 'id' },
            { data: 'nome' },
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary mr-1 botao-editar"\
                    data-id="'+ row.id +'">Editar</button>\
                    <button class="btn btn-danger botao-apagar"\
                    data-id="'+ row.id + '"> Apagar</button>';
                }
            }

        ]
    });

    $('#categoria-botao-salvar').on('click', function () {

        $nome = $('#categoria-campo-nome').val();

        if ($idPutz == -1) {
            salvar($nome);
        } else {
            alterar($nome);
        }
       
    });

    function alterar($nome) {
        $.ajax({

            url: 'https://localhost:5001/categoria/alterar',
            method: 'post',
            dataType: 'json',
            data: {
                id: $idPutz,
                nome: $nome
            },
            success: function (data) {
                $('#modal-categoria').modal('hide');
                $tabelaCategoria.ajax.reload();
                $idPutz = -1;
                $('#categoria-campo-nome').val('');
            },
            error: function (error) {
                alert('Deu Ruim');
            }
            

        });
    }

    function salvar($nome) {
        $.ajax({
            url: 'https://localhost:5001/categoria/cadastrar',
            method: 'post',
            dataType: 'json',
            data: {
                nome: $nome

            },
            success: function (data) {
                $('#modal-categoria').modal('hide');
                $tabelaCategoria.ajax.reload();
            },
            error: function (error) {
                alerta('Deu Ruim');
            }
        });
    };

    $('table').on('click', '.botao-apagar', function () {

        $id = $(this).data('id');
        $.ajax({

            url: 'https://localhost:5001/categoria/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                $tabelaCategoria.ajax.reload();
            },
            error: function (error) {
                alert('Não deu boa');
            }

        })
    });

    $('table').on('click', '.botao-editar', function () {

        $idPutz = $(this).data('id');
        $.ajax({

            url: 'https://localhost:5001/categoria/obterpeloid?id=' + $idPutz,
            method: 'get',
            success: function (data) {
                $('#categoria-campo-nome').val(data.nome);
                $('#modal-categoria').modal('show');
            },
            error: function (error) {
                alert('Deu Ruim');
            }

        })

    });
    
   
});
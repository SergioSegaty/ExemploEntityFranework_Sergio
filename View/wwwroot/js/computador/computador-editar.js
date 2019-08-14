$(function () {
    $idComputador = $('#computador-id').val();

    $("#computador-editar-categoria").select2({
        ajax: {
            url: '/categoria/obtertodosselect2',
            dataType: 'json'
        }
    })

    $('#computador-editar-salvar').on('click', function () {

        $nome = $('#computador-editar-nome').val();
        $preco = $('#computador-editar-preco').val();
        $categoria = $('#computador-editar-categoria').val();
        $.ajax({
            url: '/computador/alterar',
            method: 'post',
            data: {
                id: $idComputador,
                idCategoria: $categoria,
                nome: $nome,
                preco: $preco
            },
            success: function (data) {
                console.log('Alterado');
            },
            error: function (data) {
                console.log('Não foi possível alterar');
            }
        })
    });
})
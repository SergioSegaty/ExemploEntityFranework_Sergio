$(function () {

    $("#computador-cadastro-categoria").select2({
        ajax: {
            url: "/categoria/obtertodosselect2",
            dataType: "json",

        }

    })

});
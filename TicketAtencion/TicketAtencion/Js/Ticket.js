function ObtenerDato() {
    $.ajax({
        async: true,
        cache: false,
        url: "Main.aspx/ObtenerDato",
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset=utf-8",               
        success: function (data) {
            console.log(data);
            var a = $.parseJSON(data.d);
            console.log(a);
            $("#Dato").val(a.mensaje);
        }
    });
};

//Eventos
$("#Boton").click(function () {
    console.log("llegue aqui");
    ObtenerDato();
})
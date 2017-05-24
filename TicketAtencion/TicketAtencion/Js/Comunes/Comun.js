var WebService = {
    Consumir: function (direccion, parametros, fn_previo, fn_exito, fn_error_ws, fn_error) {
        try {
            $.ajax({
                async: true,
                cache: false,
                type: "POST",                
                beforeSend: function ()
                {
                    fn_previo();
                },
                url: direccion,
                data: parametros,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                timeout: 3600000,
                success: function (data)
                {
                    fn_exito(data);
                    return data;
                    console.log(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    fn_error(jqXHR, textStatus, errorThrown);
                }
            });
        } catch (e) {
            fn_error(e);
        }
    }
};

var Pagina = {
    Redirigir: function (pagina) {
        var url = $(location).attr('protocol') + '\\\\' + $(location).attr('host') + '\\' + pagina;

        if (url.indexOf('?') <= -1) {
            url = url + "?v=" + Math.random();
        }
        else {
            url = url + "&v=" + Math.random();
        }

        window.console && console.log(url);
        window.location.href = url;
    }
};

var Error = {
    Alerta: function (mensajePublico, mensajePrivado, informacionLocal) {
        window.console && console.log('Mensaje privado: ' + mensajePrivado);
        Mensajeria.CargardoFin();

        if (informacionLocal) {
            var htmlAlert = "<div class='alert alert-danger alert-dismissable'>";
            htmlAlert = htmlAlert + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
            htmlAlert = htmlAlert + "<span class='pficon pficon-close'></span></button>";
            htmlAlert = htmlAlert + "<span class='pficon pficon-error-circle-o'></span>";
            htmlAlert = htmlAlert + "<strong></strong>" + mensajePublico;
            htmlAlert = htmlAlert + "</div>";

            $("#mensajes").append(htmlAlert); // 
            $("#mensajes").focus();
        }
        else {
            window.console && console.log('Mensaje publico: ' + mensajePublico);
            alert('Mensaje publico: ' + mensajePublico);
        }
    }
};

var Mensajeria = {
    Exito: function (mensaje) {
        var htmlAlert = "<div class='alert alert-success alert-dismissable'>";
        htmlAlert = htmlAlert + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-close'></span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-ok'></span>";
        htmlAlert = htmlAlert + "<strong></strong>" + mensaje;
        htmlAlert = htmlAlert + "</div>";

        $("#mensajes").append(htmlAlert);
        $("#mensajes").focus();
    },

    Advertencia: function (mensaje) {
        var htmlAlert = "<div class='alert alert-warning alert-dismissable'>";
        htmlAlert = htmlAlert + "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-close'></span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-warning-triangle-o'></span>";
        htmlAlert = htmlAlert + "<strong>Advertencia</strong>" + mensaje;
        htmlAlert = htmlAlert + "</div>";

        $("#mensajes").append(htmlAlert);
        $("#mensajes").focus();
    },

    CargardoInicio: function (mensaje) {
        var htmlload = "<div class='modal fade' id='ModalLoading' role='dialog'><div class='modal-dialog'>";
        htmlload = htmlload + "<div class='modal-content'><div class='modal-body' style='padding:40px 50px; text-align: center; clear: left;'>";
        htmlload = htmlload + "<div class='panel panel-default'>";
        htmlload = htmlload + "<div class='panel-heading'><h3 class='panel-title'>Espera unos momentos</h3></div>";
        htmlload = htmlload + "<div class='panel-body'>";
        htmlload = htmlload + "<h1><div class='spinner spinner-lg spinner-inline'></div>"+mensaje+"</h1>";
        htmlload = htmlload + "</div></div></div></div>";
        htmlload = htmlload + "</div></div>";

        $("#cargando").html(htmlload);
        $("#ModalLoading").modal({ backdrop: 'static', keyboard: false });
        return false;
    },

    CargardoFin: function () {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
        $("#ModalLoading").modal("hide");
        $("#ModalLoading").remove();

        $(".modal").each(function () {
            $(this).modal("hide");
            $(this).removeClass('in')
            $(this).attr('aria-hidden', true)
            $(this).off('click.dismiss.modal');
            $(this).hide();
            $(this).remove();
        });

        $("#cargando").html("");
        return false;
    },

    ConfirmacionEliminacion: function (titulo, cuerpo, funcion) {
        var htmlload = "<div class='modal fade' id='ModalLoading' role='dialog'><div class='modal-dialog'>";
        htmlload = htmlload + "<div class='modal-content'><div class='modal-body' style='padding:40px 50px; text-align: center; clear: left;'>";
        htmlload = htmlload + "<div class='panel panel-default'>";
        htmlload = htmlload + "<div class='panel-heading'><h3 class='panel-title'>" + titulo + "</h3></div>";
        htmlload = htmlload + "<div class='panel-body'>";
        htmlload = htmlload + cuerpo;
        htmlload = htmlload + "</div>";
        htmlload = htmlload + "<div class='modal-footer'>";
        htmlload = htmlload + "<button type='button' class='btn btn-default' data-dismiss='modal' onclick='return Mensajeria.CargardoFin();'>Cancelar</button>";
        htmlload = htmlload + "<button type='button' class='btn btn-danger btn-ok' onclick='" + funcion + "'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>&nbsp;&nbsp;Eliminar</button>";
        htmlload = htmlload + "</div>";
        htmlload = htmlload + "</div></div></div>";
        htmlload = htmlload + "</div></div>";

        $("#cargando").html(htmlload);
        $("#ModalLoading").modal({ backdrop: 'static', keyboard: false });
        return false;
    }
};

var Acciones = {
    Cargando: function () {
        Mensajeria.CargardoInicio();
        setTimeout(function () {
            Mensajeria.CargardoFin();
        }, 3000);
        return false;
    },

    Exito: function (mensaje) {
        $("#mensajes").html("");
     //$("#mensajes").fadeOut(1500); 
        Mensajeria.Exito(mensaje);
        return false;
    },

    Advertencia: function () {
        $("#mensajes").html("");
        Mensajeria.Advertencia("[Problema desconosido] - Este problema no afectara los datos ingresados - pero comunique este problema lo antes posible");
        return false;
    },

    Error: function (mensaje) {
        $("#mensajes").html("");
        var mensajePublico = mensaje;
        var mensajeInterno = "";
        Error.Alerta(mensajePublico, mensajeInterno, true);
        return false;
    }

};
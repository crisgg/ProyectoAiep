var FolioDuplicador = {
    Consulta: function (direccion, texto, usuario, msg){
        var url = direccion;
        var parametros = "{ texto: '" + texto + "', usuario: '" + usuario + "'}";
        var mensaje = "Cargando Datos del Folio";
        var fn_previo = function ()
        {            
            Mensajeria.CargardoInicio(mensaje);
        };
        var fn_exito =
            function (data) {
                CargarListaTipoFolio(data);
            }; 
        var fn_error_ws = function (jqXHR, textStatus, errorThrown)
        {
            var mensajeError = "Error [" + url + "] - jqXHR: [" + jqXHR + "] - textStatus: [" + textStatus + "] - errorThrown: [" + errorThrown + "]";
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            Mensajeria.CargardoFin();
        };
        var fn_error = function (e)
        {
            var mensajeError = "Error [" + url + "] - Nombre: " + e.name + " - Mensaje: " + e.message;
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            Mensajeria.CargardoFin();
        };

        try
        {
            WebService.Consumir(url, parametros, fn_previo, fn_exito, fn_error_ws, fn_error);            
        } catch (e)
            {
            var mensajeError = "Error en metodo de FolioDuplicador - Prueba - URL[" + url + "] - Nombre: " + e.name + " - Mensaje: " + e.message;
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            Mensajeria.CargardoFin();
            }
        }
};

var CambiarFolio = {
    Consulta: function (direccion, texto, usuario, folion, msg, tipo) {
        var url = direccion;
        var parametros = "{ texto: '" + texto + "', usuario: '" + usuario + "', folion: '" + folion + "', tipo: '" + tipo + "'}";
        var mensaje = "Aplicando los Cambios";
        var fn_previo = function ()
        {
            Mensajeria.CargardoInicio(mensaje);
        };
        var fn_exito =
            function (data) {
                var obj = $.parseJSON(data.d);
                Mensajeria.CargardoFin();
                LimpiarError("txtFolioNuevo", "FolioNuevo");
                if (obj.estado) {
                    LimpiarFomulario();
                    Acciones.Exito(obj.mensaje);
                }                
                else {
                    Acciones.Error(obj.mensaje);
                    CampoError("txtFolioNuevo", "FolioNuevo", "");
                }               
            };
        var fn_error_ws = function (jqXHR, textStatus, errorThrown) {
            var mensajeError = "FN_ERROR_WS Error [" + url + "] - jqXHR: [" + jqXHR + "] - textStatus: [" + textStatus + "] - errorThrown: [" + errorThrown + "]";
            Mensajeria.CargardoFin();
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            
           
        };
        var fn_error = function (e) {
            var mensajeError = "FN_ERROR Error [" + url + "] - Nombre: " + e.name + " - Mensaje: " + e.message;
            Mensajeria.CargardoFin();
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            
            
        };

        try {
            WebService.Consumir(url, parametros, fn_previo, fn_exito, fn_error_ws, fn_error);
        } catch (e) {
            var mensajeError = "Error en metodo de FolioDuplicador - Prueba - URL[" + url + "] - Nombre: " + e.name + " - Mensaje: " + e.message;
            Mensajeria.CargardoFin();
            console.log(mensajeError);
            Acciones.Error("Problema interno");
            
        }
        
    }
};


function Cambiar() {
    var texto = $('#txtFolioAntiguo').val();
    var usuario = $('#Fwv_Usuario').val();
    var folion = $('#txtFolioNuevo').val();
    var direccion = "FolioDuplicado.aspx/CambiarFolio";
    var msg = "Cargando datos";
    var tipo = $('#cmbTipoFolio').val();
    var listaFolios = CambiarFolio.Consulta(direccion, texto, usuario, folion, msg, tipo);
 };

 function validaNumeros(e) {
     tecla = (document.all) ? e.keyCode : e.which;
     if (tecla == 8 || tecla == 13) {
         return true;
     }
     patron = /[0-9]/;
     tecla_final = String.fromCharCode(tecla);
     return patron.test(tecla_final);
 };

//funcion presionar enter en folio nuevo
 function enter(e) {
     if (e.keyCode == 13) {
         Cambiar();
     }
 };

 function Limpiar() {
     $("#txtFolioNuevo").val("");
     $("#txtFolioAntiguo").val("");
     $("#cmbTipoFolio").html("");
     $("#mensajes").html("");
     $("#txtFolioAntiguo").focus();
 };



 function LimpiarFomulario() {
     //Limpiamos los mensajes
     $("#mensajes").html("");

     //Limpiamos los campos
     $("#txtFolioAntiguo").val(""); 
     $("#cmbTipoFolio")
         .find('option')
         .remove()
         .end()
         .val("");
     $("#txtFolioNuevo").val("");

     //Ocultamos los campos temporalmente
     $("#divFormTipoFolio").hide();
     $("#divFormFolioNuevo").hide();
     $("#btnAplicarFolioDuplicado").prop('disabled', true);

     LimpiarError("txtFolioAntiguo", "FolioAntiguo");
 };

    //valida que Folio Origen no este vacio, su largo y que sea numerico
 function EsValidoBuscarTipoFolio() {
     if ($("#txtFolioAntiguo").val() == "")
     {
         return false;
     }

     var expresionNumero = /^\d+$/;
     var evaluacion = expresionNumero.test($("#txtFolioAntiguo").val())
     if (!evaluacion)
     {
         return false;
     }
     
     if ($("#txtFolioAntiguo").val().length > 14)
     {
         return false;
     }     
     return true;
     
 };

//Valida que el campo Folio Nuevo sea numerico, el largo y que no este vacio
 function EsValidoAplicarCambios() {
     if ($("#txtFolioNuevo").val() == "") {         
         return false;
     }

     var expresionNumero = /[^0-9]/;
     if (!expresionNumero.test($("#txtFolioNuevo").val())) {
         return false;
     }
     
     if ($("#txtFolioNuevo").val().length > 14) {
         return false;
     }

     return true;
 };

 function CargarTipoFolio() {
     var texto = $('#txtFolioAntiguo').val();
     var usuario = $('#Fwv_Usuario').val();
     var direccion = "FolioDuplicado.aspx/ConsultarFolio";
     var msg = "Cargando Datos del Folio";
     var listaFolios = FolioDuplicador.Consulta(direccion, texto, usuario, msg);
 };

//Limpia y carga los tipos de folio
 function CargarListaTipoFolio(data) {
     LimpiarError("txtFolioAntiguo", "FolioAntiguo");

     var obj = $.parseJSON(data.d);
     $('#cmbTipoFolio').html("");
     if (!obj.estado) {
         Acciones.Error('Error Resultado WS - ' + obj.mensaje);
     } else {
         if (obj.datos.length <= 0) {
             LimpiarFomulario();
             Mensajeria.CargardoFin();
             CampoError("txtFolioAntiguo", "FolioAntiguo", "Numero de Folio No Valido");
             return;
         }
         var options = "";
         for (var i in obj.datos) {
             options += '<option value="' + obj.datos[i].Codigo + '">' + obj.datos[i].Descripcion + '</option>';
         };
         $('#cmbTipoFolio').html(options);
         $("#divFormTipoFolio").show();
         $("#divFormFolioNuevo").show();
         $("#btnAplicarFolioDuplicado").prop('disabled', false);
     }
     Mensajeria.CargardoFin();
 };

//Muestra los errores en los campos que reciba
 function CampoError(elemento, divs, mensaje) {
     var htmlMensajeError = "<span class='help-block'>" + mensaje + "</span>";
     $("#divForm" + divs).addClass("has-error");
     $("#divElem" + divs).append(htmlMensajeError);
     $("#" + elemento).focus();
 }

//limpia los mensajes de error
 function LimpiarError(elemento, divs) {
     $("#divForm" + divs).removeClass("has-error");
     $("#divElem" + divs)
         .find('span')
         .remove();
     $("#" + elemento).focus();
 };

//*****************************************************
//*****************************************************
//*****************************************************
//                      EVENTOS
//*****************************************************
//*****************************************************
//*****************************************************

 //valida que la clase numeric entren solo numeros
 $('.numeric').on('input', function (event) {
     this.value = this.value.replace(/[^0-9]/g, '');
 });

//valida primero antes de cargar los tipos de folio
 $("#txtFolioAntiguo")
     .change(function () {
         if (EsValidoBuscarTipoFolio()) {
             CargarTipoFolio();
         }
     }
 );

//
 $("#btnLimpiarFolioDuplicado").click(function () {
    LimpiarFomulario();
 });

$("#btnAplicarFolioDuplicado").click(function () {         
    Cambiar();
});

$("#txtFolioNuevo").keydown(function (event) {
    enter(event);
});
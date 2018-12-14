// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//llamo a la api
var url = "https://localhost:44380/api/GetCarrera";
var targetDropdownC = $("#IdCarrera");
targetDropdownC.attr('disabled', false);
targetDropdownC.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownC.append($("<option value='" + json[i].IdCarrera + "' >" + json[i].DesCarrera + "</option>"));
    }
});
$("#CCCategoria").val("3");
$('#CCCategoria option[value=3]').attr('selected', 'selected');

//Reticula
var url = "https://localhost:44380/api/GetEspecialidad";
var targetDropdownE = $("#IdEspecialidad");
targetDropdownE.attr('disabled', false);
targetDropdownE.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownE.append($("<option value=" + json[i].IdEspecialidad + " >" + json[i].DesEspecialidad + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetReticula";
var targetDropdownR = $("#IdReticula");
targetDropdownR.attr('disabled', false);
targetDropdownR.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownR.append($("<option value=" + json[i].IdReticula + " >" + json[i].DesReticula + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetAlumno";
var targetDropdownA = $("#IdAlumno"); //El id este <- #Perdedora :(jaja si me quedo dormido por donde te aviso?? :( Deja que se cargue poquito mi cel y si te 
//duermes antes entonces por face, aunque si te quedas dormido no me podras avisar dahh  jajjaj jijiji cierto xd no puedo poner la monita con las manos a los  lados aqui :(
targetDropdownA.attr('disabled', false);
targetDropdownA.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownA.append($("<option value=" + json[i].IdPersona + " >" + json[i].Nombre + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetPeriodo";
var targetDropdownP = $("#IdPeriodoIngreso");
targetDropdownP.attr('disabled', false);
targetDropdownP.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownP.append($("<option value=" + json[i].IdPeriodo + " >" + json[i].DesPeriodo + "</option>"));
    }
});
var url = "https://localhost:44380/api/GetPeriodo";
var targetDropdownP2 = $("#IdPeriodoUltimo");
targetDropdownP2.attr('disabled', false);
targetDropdownP2.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownP2.append($("<option value=" + json[i].IdPeriodo + " >" + json[i].DesPeriodo + "</option>"));
    }
});
var url = "https://localhost:44380/api/GetPeriodo";
var targetDropdownP3 = $("#IdPeriodoTitulacion");
targetDropdownP3.attr('disabled', false);
targetDropdownP3.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownP3.append($("<option value=" + json[i].IdPeriodo + " >" + json[i].DesPeriodo + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetGenerales25";
var targetDropdownG25 = $("#IdGenPlanEstudio");
targetDropdownG25.attr('disabled', false);
targetDropdownG25.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownG25.append($("<option value=" + json[i].IdGeneral + " >" + json[i].DesGeneral + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetGenerales17";
var targetDropdownG17 = $("#IdGenOpcionTitulacion");
targetDropdownG17.attr('disabled', false);
targetDropdownG17.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownG17.append($("<option value=" + json[i].IdGeneral + " >" + json[i].DesGeneral + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetGenerales27";
var targetDropdownG27 = $("#IdGenNivelEscolar");
targetDropdownG27.attr('disabled', false);
targetDropdownG27.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownG27.append($("<option value=" + json[i].IdGeneral + " >" + json[i].DesGeneral + "</option>"));
    }
});

var url = "https://localhost:44380/api/GetGenerales28";
var targetDropdownG28 = $("#IdGenIngreso");
targetDropdownG28.attr('disabled', false);
targetDropdownG28.empty();
$.get(url, function (json) {
    for (var i = 0; i < json.length; i++) {
        targetDropdownG28.append($("<option value=" + json[i].IdGeneral + " >" + json[i].DesGeneral + "</option>"));
    }
});
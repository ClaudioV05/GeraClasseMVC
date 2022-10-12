$(document).ready(() =>
 {
  CarregaCboEstiloFormulario();
  CarregaCboIdeDesenvolvimento();
  CarregaCboBancoDeDados();
});

function CarregaCboEstiloFormulario()
{
  var EstiloFormulario = ["Normal", "MDI", "Windows Form", "HTML"];
  $("#cboEstiloFormulario").empty();
  $.each(EstiloFormulario, (index, value) => $("#cboEstiloFormulario").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

function CarregaCboIdeDesenvolvimento()
{
  var IdeDesenvolvimento = ["Delphi", "Lazarus", "Visual Studio"];
  $("#cboIdeDesenvolvimento").empty();
  $.each(IdeDesenvolvimento, (index, value) => $("#cboIdeDesenvolvimento").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

function CarregaCboBancoDeDados()
{
  var IdeDesenvolvimento = ["SQL Puro", "Firebird"];
  $("#cboBancoDeDados").empty();
  $.each(IdeDesenvolvimento, (index, value) => $("#cboBancoDeDados").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

// Add the following code if you want the name of the file appear on select
$(".custom-file-input").on("change", function()
{
  var fileName = $(this).val().split("\\").pop();
  $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});
$(document).ready(() =>
 {
  CarregarCboEstiloFormulario();
  CarregarCboIdeDesenvolvimento();
  CarregarCboBancoDeDados(); 
  CarregarTextArea();
});

function CarregarCboEstiloFormulario()
{
  var EstiloFormulario = ["Normal", "MDI", "Windows Form", "HTML"];
  $("#cboEstiloFormulario").empty();
  $.each(EstiloFormulario, (index, value) => $("#cboEstiloFormulario").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

function CarregarCboIdeDesenvolvimento()
{
  var IdeDesenvolvimento = ["Delphi", "Lazarus", "Visual Studio"];
  $("#cboIdeDesenvolvimento").empty();
  $.each(IdeDesenvolvimento, (index, value) => $("#cboIdeDesenvolvimento").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

function CarregarCboBancoDeDados()
{
  var IdeDesenvolvimento = ["SQL Puro", "Firebird"];
  $("#cboBancoDeDados").empty();
  $.each(IdeDesenvolvimento, (index, value) => $("#cboBancoDeDados").append(`<option value=${value.toLowerCase().replace(/\s/g, "")}>${value}</option>`));
}

function CarregarTextArea()
{
  let textarea = `This program generates 'MVC' standard class files for the 'Delphi', 'Lazarus' and" '.NET' Development Ide, from a text file containing the metadata of one or more tables.
  It is based on GeraClasseDelphi version 6.0. The difference is that it generates the files according to the 'MVC' project pattern,
  generating the Dao, Model, Controller and View files in corresponding folders. Views, Normal and Mdi style forms are created.
         
  Important:
  
  01. Font formatting obeys Delphis automatic formatter with default values, except:
  Right margin = 135
  Indent case contents = True
  
  02. For Views, there is a problem with accentuation in the display of dialog messages in Lazarus
  Adjust the Encoding of the code editor.
  Right click in code editor > File Settings > Encoding > select UTF-8 with BOM
  
  03. Version for Visual Studio in date 30.07.2022"
  
  04. New version generate class Web in 12.10.2022`

  $("#txtArea").empty().append(textarea);
  
}

var input = document.querySelector('input');
var textarea = document.querySelector('textarea');

input.addEventListener('change', function ()
{
  // Nome do arquivo Metadados
  var nomeDoArquivo = $(this).val().split("\\").pop();
  $(this).siblings(".custom-file-label").addClass("selected").html(nomeDoArquivo);

  // Carregar o arquivo metadado no TextArea
    let files = input.files;
  
    if (files.length == 0) return;

    const file = files[0];
  
    let reader = new FileReader();
  
    reader.onload = (e) =>
    {
        const file = e.target.result;
        const lines = file.split(/\r\n|\n/);
        $("#txtArea").empty();
        textarea.value = lines.join('\n');
    };
  
    reader.onerror = (e) => alert(e.target.error.name);
    reader.readAsText(file);
});
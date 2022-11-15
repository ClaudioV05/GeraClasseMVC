$(document).ready(function () {


});

var input = document.querySelector("input[name=ArquivoMetadata]");
var textarea = document.querySelector("textarea[name=InformacaoTextArea]");

$("input[name=ArquivoMetadata]").change(function () {
    // Nome do arquivo Metadados
    $(this).siblings(".custom-file-label").addClass("selected").html($(this).val().split("\\").pop());

    // Carregar o arquivo metadado no TextArea
    let files = input.files;
    if (files.length == 0) {
        return;
    }

    const file = files[0];
    let reader = new FileReader();

    reader.onload = (e) => {
        const file = e.target.result;
        const lines = file.split(/\r\n|\n/);
        $("#InformacaoTextArea").empty();
        textarea.value = lines.join("\n");
    };

    reader.onerror = (e) => alert(e.target.error.name);
    reader.readAsText(file);
});

function SatisfazCritica() {
    // Quando ficar pronto para as demais Ide, remover as validações
    let validaCriticas = true;
    let cboEstiloFormulario = $("#cboEstiloFormulario").val();
    let cboIdeDesenvolvimento = $("#cboIdeDesenvolvimento").val();
    let cboBancoDeDados = $("#cboBancoDeDados").val();

    if ($("#ArquivoMetadata").val() != undefined || $("#ArquivoMetadata").val() != null) {
        if (validaCriticas == true && $("#ArquivoMetadata").val() == "") {
            alert("Selecione o arquivo Metadados.");
            validaCriticas = false;
        }
    }

    if ((cboEstiloFormulario != undefined) && (cboEstiloFormulario != null)) {
        if (validaCriticas == true) {
            if (cboEstiloFormulario == "windowsform" || cboEstiloFormulario == "html") {
                let itemSelecionado = $('#cboEstiloFormulario :selected').text();

                alert(`Estilo de Formulário ${itemSelecionado.toUpperCase()} sem implementação.`);
                validaCriticas = false;
            }
        }
    }

    if ((cboIdeDesenvolvimento != undefined) && (cboIdeDesenvolvimento != null)) {
        if (validaCriticas == true) {
            if (cboIdeDesenvolvimento == "visualstudio") {
                let itemSelecionado = $('#cboIdeDesenvolvimento :selected').text();

                alert(`IDE de desenvolvimento ${itemSelecionado.toUpperCase()} sem implementação.`);
                validaCriticas = false;
            }
        }
    }

    if (cboBancoDeDados != undefined && cboBancoDeDados != null) {
        if (validaCriticas == true) {
            if (cboBancoDeDados == "firebird") {
                if (cboIdeDesenvolvimento == "delphi" || cboIdeDesenvolvimento == "lazarus") {
                    let itemSelecionado = $('#cboBancoDeDados :selected').text();

                    alert(`Banco de dados sem implementação para a IDE: ${itemSelecionado.toUpperCase()}.`);
                    validaCriticas = false;
                }
            }
        }
    }
    return validaCriticas;
}

$("#btnGerarClasse").on("click", function () {
    if (SatisfazCritica()) {


        document.forms[0].onsubmit;
    }
});
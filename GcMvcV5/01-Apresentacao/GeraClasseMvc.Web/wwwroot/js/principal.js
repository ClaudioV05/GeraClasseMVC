//#region Var Globais.
var input = document.querySelector("input[name=Metadados]");
var textarea = document.querySelector("textarea[name=InformacaoTextArea]");
var baseUrl = "/Principal/GeraDadosPrincipais/";
//#endregion Var Globais.

$(document).ready(function () {
    CarregaTextoBotaoConfirmar(false);
    CarregaTextoArquivoMetadados(false);
});

$("input[name=Metadados]").change(function () {
    // Carrega o nome do arquivo Metadados.
    $(this).siblings(".custom-file-label").addClass("selected").html($(this).val().split("\\").pop());

    // Carrega o texto contido no arquivo Metadados no TextArea.
    if (input != null && input != undefined) {
        let files = input.files;
        if (files.length == 0) return;

        const file = files[0];
        let reader = new FileReader();

        reader.onload = (e) => {
            const file = e.target.result;
            const lines = file.split(/\r\n|\n/);
            textarea.value = lines.join('\n');
        };

        reader.onerror = (e) => alert(e.target.error.name);
        reader.readAsText(file);
    }
});

$("#btnGerarClasse").on("click", function (event) {

    if (SatisfazCritica()) {
        EnviarDadosGeraClasse($("#dpdBancoDeDados :selected").val(),
            $("#dpdEstiloFormulario :selected").val(),
            $("#dpdIdeDesenvolvimento :selected").val(),
            $("#textAreaMetadados").val());
    }
    else {
        event.preventDefault();
    }
});

function SatisfazCritica() {
    // Quando todas as implementações estiverem prontas, remover as validações do DropDown. Manter o arquivo Metadata.
    let validaCriticas = true;

    //#region Validação do arquivo Metadata.
    if ($("#textAreaMetadados").val() != undefined || $("#textAreaMetadados").val() != null) {
        if (validaCriticas == true && $("#textAreaMetadados").val() == "") {
            alert("Selecione o arquivo Metadados.");
            validaCriticas = false;
        }
    }
    //#endregion Validação do arquivo Metadata.

    //#region Validação da IDE de desenvolvimento.
    if (($("#dpdIdeDesenvolvimento").val() != undefined) && ($("#dpdIdeDesenvolvimento").val() != null)) {
        if (validaCriticas == true) {
            if ($("#dpdIdeDesenvolvimento").val() == "visualstudio") {
                let itemSelecionado = $("#dpdIdeDesenvolvimento :selected").text();

                alert(`IDE de desenvolvimento ${itemSelecionado.toUpperCase()} sem implementação.`);
                validaCriticas = false;
            }
        }
    }
    //#endregion Validação da IDE de desenvolvimento.

    //#region Validação do estilo do formulário.
    if (($("#dpdEstiloFormulario").val() != undefined) && ($("#dpdEstiloFormulario").val() != null)) {
        if (validaCriticas == true) {
            if ($("#dpdEstiloFormulario").val() == "windowsform" || $("#dpdEstiloFormulario").val() == "aspnetmvc") {
                let itemSelecionado = $("#dpdEstiloFormulario :selected").text();

                alert(`Estilo de Formulário ${itemSelecionado.toUpperCase()} sem implementação.`);
                validaCriticas = false;
            }
        }
    }
    //#endregion Validação do estilo do formulário.

    //#region Validação da Engine do banco de dados.
    if ($("#dpdBancoDeDados").val() != "undefined" && $("#dpdBancoDeDados").val() != null) {
        if (validaCriticas == true) {
            if ($("#dpdBancoDeDados").val() == "firebird") {
                if ($("#dpdBancoDeDados").val() == "delphi" || $("#dpdBancoDeDados").val() == "lazarus") {
                    let itemSelecionado = $("#dpdBancoDeDados :selected").text();

                    alert(`Banco de dados sem implementação para a IDE: ${itemSelecionado.toUpperCase()}.`);
                    validaCriticas = false;
                }
            }
        }
    }
    //#endregion Validação da Engine do banco de dados.

    return validaCriticas;
}

function EnviarDadosGeraClasse(tipoBancoDeDados, tipoEstiloFormulario, tipoIdeDesenvolvimento, metadados) {
    $.ajax({
        url: baseUrl + "?TipoBancoDeDados=" + tipoBancoDeDados + "&TipoEstiloFormulario=" + tipoEstiloFormulario + "&TipoIdeDesenvolvimento=" + tipoIdeDesenvolvimento + "&Metadados=" + metadados,
        method: "POST",
        contentType: "application/json",
        success: function (res) {
            console.log(`Sucesso ${res}`);
        },
        error: function (err) {
            alert(`Sem conexão com o servidor.\n ${err}`);
        }
    });
}

window.onresize = function () {
    let tamanhoTela = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
    RedimensionaTela(tamanhoTela);
};

function RedimensionaTela(tamanhoTela) {
    //#region Texto Botão Confirmar.
    if (tamanhoTela < 380) {
        CarregaTextoBotaoConfirmar(true);
    }
    else {
        CarregaTextoBotaoConfirmar(false);
    }
    //#endregion Texto Botão Confirmar.

    //#region Texto Arquivo Metadados.
    if (tamanhoTela < 380) {
        CarregaTextoArquivoMetadados(true);
    }
    else {
        CarregaTextoArquivoMetadados(false);
    }
    //#endregion Texto Arquivo Metadados.
}

function CarregaTextoBotaoConfirmar(textoDimensionado) {

    if (textoDimensionado != undefined && textoDimensionado == true) {
        $("#titulo-botao-confirmar").text("Ok!");
    }
    else {
        $("#titulo-botao-confirmar").text("Confirmar");
    }
}

function CarregaTextoArquivoMetadados(textoDimensionado) {

    if (textoDimensionado != undefined && textoDimensionado == true) {
        $(".custom-file-label").text("Arquivo");
    }
    else {
        $(".custom-file-label").text("Arquivo Metadados");
    }
}
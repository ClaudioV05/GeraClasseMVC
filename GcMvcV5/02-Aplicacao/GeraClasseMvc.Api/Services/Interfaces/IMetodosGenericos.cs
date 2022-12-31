using GeraClasseMvc.Api.Models;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    /// <summary>
    /// Interface IMetodosGenericos.
    /// </summary>
    public interface IMetodosGenericos
    {
        /// <summary>
        /// Listagem do Bancos de Dados.
        /// </summary>
        List<string> ListagemBancosDeDados();

        /// <summary>
        /// Listagem Estilo do Formulário.
        /// </summary>
        List<string> ListagemEstiloFormulario();

        /// <summary>
        /// Listagem IDE de Desenvolvimento.
        /// </summary>
        List<string> ListagemIdeDesenvolvimento();

        /// <summary>
        /// Método para Retornar o Tipo do Banco de Dados.
        /// </summary>
        TipoBancodeDados RetornaTipoBancoDeDados(string bancodedados);
    }
}
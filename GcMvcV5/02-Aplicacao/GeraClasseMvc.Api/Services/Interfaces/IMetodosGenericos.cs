using GeraClasseMvc.Api.Models;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IMetodosGenericos
    {
        List<string> ListagemBancosDeDados();
        List<string> ListagemEstiloFormulario();
        List<string> ListagemIdeDesenvolvimento();
        TipoBancodeDados RetornaTipoBancoDeDados(string bancodedados);
    }
}
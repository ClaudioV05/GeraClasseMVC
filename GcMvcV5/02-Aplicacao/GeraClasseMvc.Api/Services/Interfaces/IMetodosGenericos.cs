using GeraClasseMvc.Api.Models;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IMetodosGenericos
    {
        TipoBancodeDados RetornaTipoBancoDeDados(string bancodedados);
        IEnumerable<string> DescricaoBancosDeDados();
        IEnumerable<string> DescricaoIdeDesenvolvimento();
        IEnumerable<string> DescricaoEstiloFormulario();
    }
}
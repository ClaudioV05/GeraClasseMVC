using GeraClasseMvc.Api.Models;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IMetodosGenericos
    {
        TipoBancodeDados RetornaTipoBancoDeDados(string bancodedados);
    }
}
using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;

namespace GeraClasseMvc.Api.Services
{
    public class MetodosGenericos : IMetodosGenericos
    {
        public TipoBancodeDados RetornaTipoBancoDeDados(string bancodedados)
        {
            switch (bancodedados)
            {
                case "sqlpuro":
                    return TipoBancodeDados.SqlPuro;
                    break;
                case "firebird":
                    return TipoBancodeDados.Firebird;
                    break;
                default:
                    return TipoBancodeDados.NaoEncontrado;
                    break;
            }
        }
    }
}
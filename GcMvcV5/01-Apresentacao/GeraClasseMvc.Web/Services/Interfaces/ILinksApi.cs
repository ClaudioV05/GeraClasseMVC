using GeraClasseMvc.Api.Models;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services.Interfaces
{
    public interface ILinksApi
    {
        Task<TipoBancodeDados> RetornaTipoBancoDeDados(string bancoDeDados);
    }
}
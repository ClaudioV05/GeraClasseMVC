using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    /// <summary>
    /// Tipo Enumerado TipoIdeDesenvolvimento para a Entidade IDE de Desenvolvimento.
    /// </summary>
    public enum TipoIdeDesenvolvimento : byte
    {
        NaoDefinido = 0,
        DelphiXe10 = 1,
        Lazarus = 2,
        NetVisualStudio = 3
    }

    /// <summary>
    /// Entidade IDE de Desenvolvimento.
    /// </summary>
    [ComplexType]
    public class IdeDesenvolvimento
    {
        public IdeDesenvolvimento()
        {
            this.Id = TipoIdeDesenvolvimento.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "Delphi", "Lazarus", "Visual Studio" };
        }

        /// <summary>
        /// Id do TipoIdeDesenvolvimento.
        /// </summary>
        public TipoIdeDesenvolvimento Id { get; set; }
        /// <summary>
        /// Descrição da IDE de Desenvolvimento.
        /// </summary>
        public List<string> Descricao { get; set; }
    }
}
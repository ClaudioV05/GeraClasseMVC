using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    public enum TipoIdeDesenvolvimento : byte
    {
        NaoDefinido = 0,
        DelphiXe10 = 1,
        Lazarus = 2,
        NetVisualStudio = 3
    }

    [ComplexType]
    public class IdeDesenvolvimento
    {
        public IdeDesenvolvimento()
        {
            this.Id = TipoIdeDesenvolvimento.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "Delphi", "Lazarus", "Visual Studio" };
        }

        public TipoIdeDesenvolvimento Id { get; set; }
        public List<string> Descricao { get; set; }
    }
}
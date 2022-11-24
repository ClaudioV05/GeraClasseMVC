using System.Collections.Generic;

namespace GeraClasseMvc.Api.Models
{
    public enum TipoIdeDesenvolvimento : byte
    {
        NaoDefinido = 0,
        DelphiXe10 = 1,
        Lazarus = 2,
        NetVisualStudio = 3
    }

    public class IdeDesenvolvimento
    {
        public IdeDesenvolvimento()
        {
            this.IdTipoIdeDesenvolvimento = TipoIdeDesenvolvimento.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "Delphi", "Lazarus", "Visual Studio" };
        }

        public TipoIdeDesenvolvimento IdTipoIdeDesenvolvimento { get; set; }
        public List<string> Descricao { get; set; }
    }
}
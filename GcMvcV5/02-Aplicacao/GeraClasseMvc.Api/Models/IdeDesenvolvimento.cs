namespace GeraClasseMvc.Api.Models
{
    public enum TipoIdeDesenvolvimento : byte
    {
        NaoEncontrado = 0,
        Delphi = 1,
        Lazarus = 2,
        VisualStudio = 3
    }

    public class IdeDesenvolvimento
    {
        public TipoIdeDesenvolvimento Id { get; set; }

        public string Descricao { get; set; }
    }
}
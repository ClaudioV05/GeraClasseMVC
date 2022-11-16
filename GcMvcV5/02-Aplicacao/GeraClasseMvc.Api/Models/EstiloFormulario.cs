namespace GeraClasseMvc.Api.Models
{
    public enum TipoEstiloFormulario : byte
    {
        NaoEncontrado = 0,
        Normal = 1,
        MDI = 2,
        WindowsForm = 3,
        Html = 4
    }

    public class EstiloFormulario
    {
        public TipoEstiloFormulario IdTipoBancodeDados { get; set; }

        public string? Descricao { get; set; }
    }
}
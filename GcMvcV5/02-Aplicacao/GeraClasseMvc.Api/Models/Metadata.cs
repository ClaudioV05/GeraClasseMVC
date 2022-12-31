namespace GeraClasseMvc.Api.Models
{
   
    public class Metadata
    {
        public Metadata()
        {
            this.BancodeDados = new BancodeDados();
            this.EstiloFormulario = new EstiloFormulario();
            this.IdeDesenvolvimento = new IdeDesenvolvimento();
        }

        public string? ScriptMetadata { get; set; }
        public BancodeDados? BancodeDados { get; set; }
        public EstiloFormulario? EstiloFormulario { get; set; }
        public IdeDesenvolvimento? IdeDesenvolvimento { get; set; }
    }
}
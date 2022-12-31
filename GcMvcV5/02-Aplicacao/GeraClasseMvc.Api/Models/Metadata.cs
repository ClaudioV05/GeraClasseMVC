namespace GeraClasseMvc.Api.Models
{
    /// <summary>
    /// Entidade Metadata.
    /// </summary>
    public class Metadata
    {
        public Metadata()
        {
            this.BancodeDados = new BancodeDados();
            this.EstiloFormulario = new EstiloFormulario();
            this.IdeDesenvolvimento = new IdeDesenvolvimento();
        }

        /// <summary>
        /// Contém o script do metadata.
        /// </summary>
        public string? ScriptMetadata { get; set; }
        /// <summary>
        /// Entidade Banco de Dados.
        /// </summary>
        public BancodeDados? BancodeDados { get; set; }
        /// <summary>
        /// Entidade Estilo do Formulário.
        /// </summary>
        public EstiloFormulario? EstiloFormulario { get; set; }
        /// <summary>
        /// Entidade IDE de Desenvolvimento.
        /// </summary>
        public IdeDesenvolvimento? IdeDesenvolvimento { get; set; }
    }
}
using System;

namespace GeraClasseMvc.Api.Models
{
    /// <summary>
    /// Entidade Principal Gera Classe Responsável por Criar Todos os arquivos.
    /// </summary>
    public class GeraClasse
    {
        public GeraClasse()
        {
            try
            {
                this.Metadados = string.Empty;
                this.MetadadosBase64 = string.Empty;
                this.BancodeDadosBase64 = string.Empty;
                this.EstiloFormularioBase64 = string.Empty;
                this.IdeDesenvolvimentoBase64 = string.Empty;
                this.BancodeDados = new BancodeDados();
                this.EscolheCampos = new EscolheCampos();
                this.EscolheTabelas = new EscolheTabelas();
                this.EstiloFormulario = new EstiloFormulario();
                this.IdeDesenvolvimento = new IdeDesenvolvimento();
            }
            catch (Exception)
            {
                throw new Exception("Erro na criação do" + this.ToString());
            }
        }

        /// <summary>
        /// Contém o script do metadados.
        /// </summary>
        public string? Metadados { get; set; }
        /// <summary>
        /// Contém o script do metadata no formato Base64.
        /// </summary>
        public string? MetadadosBase64 { get; set; }
        /// <summary>
        /// Contém o Tipo do banco de dados no formato Base64.
        /// </summary>
        public string? BancodeDadosBase64 { get; set; }
        /// <summary>
        /// Contém o Tipo do Estilo Formulário no formato Base64.
        /// </summary>
        public string? EstiloFormularioBase64 { get; set; }
        /// <summary>
        /// Contém o Tipo da IDE de Desenvolvimento no formato Base64.
        /// </summary>
        public string? IdeDesenvolvimentoBase64 { get; set; }
        /// <summary>
        /// Entidade Banco de Dados.
        /// </summary>
        public BancodeDados? BancodeDados { get; set; }
        /// <summary>
        /// Entidade Escolhe Campos.
        /// </summary>
        public EscolheCampos? EscolheCampos { get; set; }
        /// <summary>
        /// Entidade Escolhe Tabelas.
        /// </summary>
        public EscolheTabelas? EscolheTabelas { get; set; }
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
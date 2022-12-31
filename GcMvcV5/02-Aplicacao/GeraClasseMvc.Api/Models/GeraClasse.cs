using System;
using System.Collections.Generic;

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
        /// Contém o script do metadata.
        /// </summary>
        public string? ScriptMetadata { get; set; }

        /// <summary>
        /// Contém o script do metadata no formato Base64.
        /// </summary>
        public string? ScriptMetadataBase64 { get; set; }

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
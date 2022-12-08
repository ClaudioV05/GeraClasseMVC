using System;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Models
{
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

        public string? ScriptMetadata { get; set; }
        public BancodeDados? BancodeDados { get; set; }
        public EscolheCampos? EscolheCampos { get; set; }
        public EscolheTabelas? EscolheTabelas { get; set; }
        public EstiloFormulario? EstiloFormulario { get; set; }
        public IdeDesenvolvimento? IdeDesenvolvimento { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    /// <summary>
    /// Tipo Enumerado TipoEstiloFormulario para a Entidade Estilo Formulário.
    /// </summary>
    public enum TipoEstiloFormulario : byte
    {
        NaoDefinido = 0,
        DelphiNormalMdi = 1,
        LazarusNormalMdi = 2,
        DotnetWindowsForm = 3,
        DotnetAspNetMvc = 4
    }

    /// <summary>
    /// Entidade Estilo Formulário.
    /// </summary>
    [ComplexType]
    public class EstiloFormulario
    {
        public EstiloFormulario()
        {
            this.Id = TipoEstiloFormulario.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "Normal", "MDI", "Windows Form", "Asp Net MVC" };
        }

        /// <summary>
        /// Id do TipoEstiloFormulario.
        /// </summary>
        public TipoEstiloFormulario Id { get; set; }

        /// <summary>
        /// Descrição do Estilo do Formulário.
        /// </summary>
        public List<string> Descricao { get; set; }
    }
}
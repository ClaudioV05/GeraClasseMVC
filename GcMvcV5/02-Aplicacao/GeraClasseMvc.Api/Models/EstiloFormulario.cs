using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    public enum TipoEstiloFormulario : byte
    {
        NaoDefinido = 0,
        DelphiNormalMdi = 1,
        LazarusNormalMdi = 2,
        DotnetWindowsForm = 3,
        DotnetAspNetMvc = 4
    }

    [ComplexType]
    public class EstiloFormulario
    {
        public EstiloFormulario()
        {
            this.Id = TipoEstiloFormulario.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "Normal", "MDI", "Windows Form", "Asp Net MVC" };
        }

        public TipoEstiloFormulario Id { get; set; }
        public List<string> Descricao { get; set; }
    }
}
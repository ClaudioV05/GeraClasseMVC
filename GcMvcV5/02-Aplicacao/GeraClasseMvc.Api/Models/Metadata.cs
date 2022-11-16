using System.Collections.Generic;

namespace GeraClasseMvc.Api.Models
{
    public class Metadata
    {
        public string ScriptMetadata { get; set; }

        public BancodeDados BancodeDados { get; set; }

        public EstiloFormulario EstiloFormulario { get; set; }

        public IdeDesenvolvimento IdeDesenvolvimento { get; set; }
    }
}
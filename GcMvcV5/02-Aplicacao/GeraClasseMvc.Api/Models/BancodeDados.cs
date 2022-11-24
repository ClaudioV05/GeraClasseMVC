using System.Collections.Generic;

namespace GeraClasseMvc.Api.Models
{
    public enum TipoBancodeDados : byte
    {
        NaoDefinido = 0,
        SgdbMySql = 1,
        SgdbFirebird = 2,
    }

    public class BancodeDados
    {
        public BancodeDados()
        {
            this.IdTipoBancodeDados = TipoBancodeDados.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "MySql", "Firebird" };
        }

        public TipoBancodeDados IdTipoBancodeDados { get; set; }
        public List<string> Descricao { get; set; }
    }
}
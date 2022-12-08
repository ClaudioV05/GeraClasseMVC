using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    public enum TipoBancodeDados : byte
    {
        NaoDefinido = 0,
        SgdbMySql = 1,
        SgdbFirebird = 2,
    }

    [ComplexType]
    public class BancodeDados
    {
        public BancodeDados()
        {
            this.Id = TipoBancodeDados.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "MySql", "Firebird" };
        }

        public TipoBancodeDados Id { get; set; }
        public List<string> Descricao { get; set; }
    }
}
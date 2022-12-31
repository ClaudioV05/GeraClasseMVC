using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraClasseMvc.Api.Models
{
    /// <summary>
    /// Tipo Enumerado TipoBancodeDados para a Entidade Banco de Dados.
    /// </summary>
    public enum TipoBancodeDados : byte
    {
        NaoDefinido = 0,
        SgdbMySql = 1,
        SgdbFirebird = 2,
    }

    /// <summary>
    /// Entidade Banco de Dados.
    /// </summary>
    [ComplexType]
    public class BancodeDados
    {
        public BancodeDados()
        {
            this.Id = TipoBancodeDados.NaoDefinido;
            this.Descricao = new List<string>() { "NaoDefinido", "MySql", "Firebird" };
        }

        /// <summary>
        /// Id do TipoBancodeDados.
        /// </summary>
        public TipoBancodeDados Id { get; set; }
        /// <summary>
        /// Descrição do Banco de dados.
        /// </summary>
        public List<string> Descricao { get; set; }
    }
}
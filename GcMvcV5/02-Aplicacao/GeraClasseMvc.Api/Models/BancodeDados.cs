namespace GeraClasseMvc.Api.Models
{
    public enum TipoBancodeDados : byte
    {
        NaoEncontrado = 0,
        SqlPuro = 1,
        Firebird = 2,
    }

    public class BancodeDados
    {
        public TipoBancodeDados Id { get; set; }

        public string Descricao { get; set; }
    }
}
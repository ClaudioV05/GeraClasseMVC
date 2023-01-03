namespace Utils.ConversorBase64.Interfaces
{
    public interface IConversor
    {
        string DecodificaDeBase64(string data);
        string CodificaParaBase64(string data);
    }
}
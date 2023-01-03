using System;
using System.Text;
using Utils.ConversorBase64.Interfaces;

namespace Utils.ConversorBase64.Services
{
    public class Conversor : IConversor
    {
        public string CodificaParaBase64(string data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(data);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DecodificaDeBase64(string data)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                return ASCIIEncoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
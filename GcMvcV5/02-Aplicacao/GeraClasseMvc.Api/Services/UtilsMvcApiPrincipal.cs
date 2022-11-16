using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Services
{
    public class UtilsMvcApiPrincipal : IUtilsMvcApiPrincipal
    {
        public async Task<Metadata> RetornaDescricaoTabelas(string baseURL, Metadata metadata)
        {
            var myContent = JsonConvert.SerializeObject(metadata);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL, byteContent))
                {
                    using (HttpContent content = res.Content)
                    {
                        //string data = await content.ReadAsStringAsync();
                        //if (data != null)
                        //{
                        //    return data;
                        //}
                    }
                }
            }
            return null;
        }


    }
}
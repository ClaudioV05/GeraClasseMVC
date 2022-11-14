using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using GeraClasseMvc.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeraClasseMvc.Web.Services
{
    public class Utils : IUtils
    {
        public Utils(IConfiguration configuration)
        {
            this.NomeDaVersaoAplicacao = configuration["GeraClasseMvc:NomeDaVersaoAplicacao"];
            this.NomeDaAplicacao = configuration["GeraClasseMvc:NomeDaAplicacao"];
            this.AnoVersaoAplicacao = DateTime.Now.Year.ToString();
            this.IdeDesenvolvimentoListItem = CarregaIdeDesenvolvimento();          
        }

        public string NomeDaVersaoAplicacao { get; set; }

        public string NomeDaAplicacao { get; set; }

        public string AnoVersaoAplicacao { get; set; }

        public IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        #region CarregaIdeDesenvolvimento
        public IEnumerable<SelectListItem> CarregaIdeDesenvolvimento()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> ideDesenvolvimento = new List<string>() { "Delphi", "Lazarus", "Visual Studio" };

            try
            {
                if (ideDesenvolvimento.Count > 0)
                {
                    for (int i = 0; i < ideDesenvolvimento.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(ideDesenvolvimento[i]))
                        {
                            lista.Add(new SelectListItem() { Value = ideDesenvolvimento[i].ToLower(), Text = ideDesenvolvimento[i] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }
        #endregion CarregaIdeDesenvolvimento
    }
}
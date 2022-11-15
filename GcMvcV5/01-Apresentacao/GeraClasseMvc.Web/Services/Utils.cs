using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GeraClasseMvc.Web.Services
{
    public class Utils : IUtils
    {
        private readonly IConfiguration _configuration;
        public Utils(IConfiguration configuration)
        {
            _configuration = configuration;

            this.NomeDaVersaoAplicacao = CarregarNomeDaVersaoAplicacao();
            this.NomeDaAplicacao = CarregarNomeDaAplicacao();
            this.AnoVersaoAplicacao = CarregarAnoVersaoAplicacao();
            this.InformacaoTextArea = CarregarInformacaoTextArea();
            this.IdeDesenvolvimentoListItem = CarregarListaIdeDesenvolvimento();
            this.EstiloFormularioListItem = CarregarListaEstiloFormulario();
            this.BancoDeDadosListItem = CarregarListaBancoDeDados();
        }

        public string NomeDaVersaoAplicacao { get; set; }

        public string NomeDaAplicacao { get; set; }

        public string AnoVersaoAplicacao { get; set; }

        public string InformacaoTextArea { get; set; }

        public IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        public IEnumerable<SelectListItem> EstiloFormularioListItem { get; set; }

        public IEnumerable<SelectListItem> BancoDeDadosListItem { get; set; }

        #region CarregarListaIdeDesenvolvimento
        private static IEnumerable<SelectListItem> CarregarListaIdeDesenvolvimento()
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
                            lista.Add(new SelectListItem() { Value = ideDesenvolvimento[i].Replace(" ", "").ToLower(), Text = ideDesenvolvimento[i] });
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
        #endregion CarregarListaIdeDesenvolvimento

        #region CarregarListaEstiloFormulario
        private static IEnumerable<SelectListItem> CarregarListaEstiloFormulario()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> estiloFormulario = new List<string>() { "Normal", "MDI", "Windows Form", "HTML" };

            try
            {
                if (estiloFormulario.Count > 0)
                {
                    for (int i = 0; i < estiloFormulario.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(estiloFormulario[i]))
                        {
                            lista.Add(new SelectListItem() { Value = estiloFormulario[i].Replace(" ", "").ToLower(), Text = estiloFormulario[i] });
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
        #endregion CarregarListaEstiloFormulario

        #region CarregarListaBancoDeDados
        private static IEnumerable<SelectListItem> CarregarListaBancoDeDados()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            List<string> bancoDeDados = new List<string>() { "SQL Puro", "Firebird" };

            try
            {
                if (bancoDeDados.Count > 0)
                {
                    for (int i = 0; i < bancoDeDados.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(bancoDeDados[i]))
                        {
                            lista.Add(new SelectListItem() { Value = bancoDeDados[i].Replace(" ", "").ToLower(), Text = bancoDeDados[i] });
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
        #endregion CarregarListaBancoDeDados

        #region CarregarAnoVersaoAplicacao
        private string CarregarAnoVersaoAplicacao() => DateTime.Now.Year.ToString();
        #endregion CarregarAnoVersaoAplicacao

        #region CarregarNomeDaVersaoAplicacao
        private string CarregarNomeDaVersaoAplicacao() => _configuration["GeraClasseMvc:NomeDaVersaoAplicacao"];
        #endregion CarregarNomeDaVersaoAplicacao

        #region CarregarNomeDaAplicacao
        private string CarregarNomeDaAplicacao() => _configuration["GeraClasseMvc:NomeDaAplicacao"];
        #endregion CarregarNomeDaAplicacao

        #region CarregarInformacaoTextArea
        private static string CarregarInformacaoTextArea()
        {
            return "This program generates 'MVC' standard class files for the 'Delphi', 'Lazarus' and '.NET' Development Ide, from a text file containing the metadata of one or more tables.\n" +
                   "It is based on GeraClasseDelphi version 6.0. The difference is that it generates the files according to the 'MVC' project pattern,\n" +
                   "generating the Dao, Model, Controller and View files in corresponding folders.Views, Normal and Mdi style forms are created.\n\n" +

                   "Important:\n\n" +

                   "01. Font formatting obeys Delphis automatic formatter with default values, except:\n" +
                   "Right margin = 135\n" +
                   "Indent case contents = True\n\n" +

                   "02. For Views, there is a problem with accentuation in the display of dialog messages in Lazarus\n" +
                   "Adjust the Encoding of the code editor.\n" +
                   "Right click in code editor > File Settings > Encoding > select UTF-8 with BOM\n\n" +

                   "03. Version for Visual Studio in date 30.07.2022\n\n" +

                   "04. New version generate class Web in 12.10.2022";
        }
        #endregion CarregarInformacaoTextArea
    }
}
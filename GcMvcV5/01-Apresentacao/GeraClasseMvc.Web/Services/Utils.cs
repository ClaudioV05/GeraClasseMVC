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
            this.IdeDesenvolvimentoListItem = CarregarListaIdeDesenvolvimento();
            this.EstiloFormularioListItem = CarregarListaEstiloFormulario();
            this.BancoDeDadosListItem = CarregarListaBancoDeDados();
        }

        public string NomeDaVersaoAplicacao { get; set; }
        public string NomeDaAplicacao { get; set; }
        public string AnoVersaoAplicacao { get; set; }
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
    }
}
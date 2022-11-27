using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeraClasseMvc.Api.Services
{
    public class MetodosGenericos : IMetodosGenericos
    {
        private readonly BancodeDados _bancodeDados;
        private readonly EstiloFormulario _estiloFormulario;
        private readonly IdeDesenvolvimento _ideDesenvolvimento;

        public MetodosGenericos()
        {
            _bancodeDados = new BancodeDados();
            _estiloFormulario = new EstiloFormulario();
            _ideDesenvolvimento = new IdeDesenvolvimento();
        }

        public List<string> DescricaoBancoDeDados() => _bancodeDados.Descricao;

        public List<string> DescricaoEstiloFormulario() => _estiloFormulario.Descricao;

        public List<string> DescricaoIdeDesenvolvimento() => _ideDesenvolvimento.Descricao;

        public TipoBancodeDados TipoBancoDeDados(string? bancodedados)
        {
            object? tpBancodeDados = TipoBancodeDados.NaoDefinido;
            string? descBancoDeDados = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(bancodedados))
                {
                    var idBancoDeDados = _bancodeDados.Descricao.FindIndex(e => e.ToLower().Equals(bancodedados.Trim()));

                    if (idBancoDeDados > 0)
                    {
                        descBancoDeDados = Enum.GetName(typeof(TipoBancodeDados), idBancoDeDados);
                        tpBancodeDados = Enum.Parse(typeof(TipoBancodeDados), descBancoDeDados);
                    }
                }
            }
            catch (Exception)
            {
                tpBancodeDados = TipoBancodeDados.NaoDefinido;
            }
            return (TipoBancodeDados)tpBancodeDados;
        }
    }
}
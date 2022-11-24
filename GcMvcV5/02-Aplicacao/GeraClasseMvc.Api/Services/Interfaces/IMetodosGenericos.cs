﻿using GeraClasseMvc.Api.Models;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IMetodosGenericos
    {
        TipoBancodeDados TipoBancoDeDados(string bancodedados);
        List<string> DescricaoBancoDeDados();
        List<string> DescricaoIdeDesenvolvimento();
        List<string> DescricaoEstiloFormulario();
    }
}
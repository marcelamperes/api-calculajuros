using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        [Route("calculajuros")]
        /// <summary>
        /// Método que retorna o cálculo
        /// </summary>
        /// <returns>cálculo</returns>
        public decimal GetCalculoJuros(decimal valorinicial, int meses)
        {
            //Valor Final = Valor Inicial *(1 + juros) ^ Tempo
            //Valor inicial é um decimal recebido como parâmetr
            //Valor do Juros deve ser consultado na API 1
            //Tempo é um inteiro, que representa meses, também recebido como parâmetro
            //^ representa a operação de potência
            //Resultado final deve ser truncado (sem arredondamento) em duas casas decimais
            //Exemplo: /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10


            decimal juros = Convert.ToDecimal(0.01);
            return juros;
        }

        [HttpGet]
        [Route("showmethecode")]
        /// <summary>
        /// Método que retorna a URL do código fonte do projeto no Git
        /// </summary>
        /// <returns>url git</returns>
        public string GetUrlCode()
        {
            return "https://github.com/marcelamperes/api-calculajuros";
        }
    }
}

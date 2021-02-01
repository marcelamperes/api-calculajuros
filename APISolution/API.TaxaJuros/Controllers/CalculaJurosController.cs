using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private IConfiguration _config;

        public CalculaJurosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        #region endpoints

        /// <summary>
        /// Método que retorna o cálculo
        /// </summary>
        /// <returns>cálculo</returns>
        [HttpGet]
        [Route("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCalculoJuros(double valorinicial, int meses)
        {
            try
            {
                double calculo;

                //Acessa o endpoint que retorna o valor da taxa de juros
                var client = new HttpClient();
                var response = await client.GetAsync("https://localhost:5001/taxaJuros");
                var resultado = response.Content.ReadAsStringAsync().Result;

                var juros = Convert.ToDouble(resultado) / 100;

                var multiplicacao = valorinicial * (1 + juros);
                var tempo = Convert.ToDouble(meses);

                calculo = Math.Pow(multiplicacao, tempo) / 100000000;

                return Ok(string.Format("{0:0.00}", calculo));
                //return Ok(Math.Round(calculo, 2));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Método que retorna a URL do código fonte do projeto no Git
        /// </summary>
        /// <returns>url git</returns>
        [HttpGet]
        [Route("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUrlCode()
        {
            try
            {
                var urlGit = _config.GetSection("UrlGit").Value;
                return Ok(urlGit);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}

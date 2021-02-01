using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private IConfiguration _config;

        public TaxaJurosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        #region endpoints

        /// <summary>
        /// Método que retorna o valor do juros
        /// </summary>
        /// <returns>juros</returns>
        [HttpGet]
        [Route("taxaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTaxaJuros()
        {
            try
            {
                var juros = _config.GetSection("TaxaJuros").Value;
                return Ok(juros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}

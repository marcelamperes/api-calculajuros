using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Route("taxaJuros")]
        /// <summary>
        /// Método que retorna o valor do juros
        /// </summary>
        /// <returns>juros</returns>
        public decimal GetTaxaJuros()
        {
            decimal juros = Convert.ToDecimal(0.01);
            return juros;
        }
    }
}

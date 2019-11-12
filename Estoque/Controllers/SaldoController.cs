using Estoque.Business.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estoque.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("saldo")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SaldoController : ControllerBase
    {

        private ISaldoBusiness _saldoBusiness;

        public SaldoController(ISaldoBusiness saldoBusiness)
        {
            _saldoBusiness = saldoBusiness;
        }

        #region GET
        [HttpGet("entrada/{material}", Name = "SaldoEntrada")]
        public async Task<IActionResult> FindQtdByMaterial(string material)
        {
            try
            {
                if (string.IsNullOrEmpty(material))
                    return BadRequest(ModelState);


                var qtdentradas = _saldoBusiness.FindQtdByMaterial(material);

                if (qtdentradas.Equals(0))
                    return NotFound("Nenhuma entrada encontrada correspondente com o material solicitado!");

                return Ok("Quantidade total cadastrada: " + qtdentradas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("saida/{material}", Name = "SaldoSaida")]
        public async Task<IActionResult> FindQtdRetiradaByMaterial(string material)
        {
            try
            {
                if (string.IsNullOrEmpty(material))
                    return BadRequest(ModelState);

                var qtdsaidas = _saldoBusiness.FindQtdRetiradaByMaterial(material);

                if (qtdsaidas.Equals(0))
                    return NotFound("Nenhuma retirada encontrada correspondente com o material solicitado!");

                return Ok("Quantidade total retirada: " + qtdsaidas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("material/{descricao}", Name = "QuantidadeTotalEstoque")]
        public async Task<IActionResult> QuantidadeTotalEstoque(string descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                    return BadRequest(ModelState);

                var material = _saldoBusiness.SaldoMaterial(descricao);
                if (material.Equals(0))
                    return NotFound("Nenhuma unidade no estoque correspondente a este material!");

                return Ok(material);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        #endregion
    }
}


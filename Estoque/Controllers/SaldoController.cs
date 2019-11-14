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


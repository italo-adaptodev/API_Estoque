using Estoque.Business.interfaces;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estoque.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("saidaestoque")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SaidaEstoqueController : ControllerBase
    {
        private ISaidaEstoqueBusiness _saidaEstoqueBusiness;

        public SaidaEstoqueController(ISaidaEstoqueBusiness saidaEstoqueBusiness)
        {
            _saidaEstoqueBusiness = saidaEstoqueBusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllSaidas")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var saidas = await _saidaEstoqueBusiness.FindAll();
                if (saidas.Count > 0)
                    
                    return Ok(saidas);

                return NotFound("Nenhuma saida encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "FindByIdSaida")]
        public async Task<IActionResult> FindById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var Saida = await _saidaEstoqueBusiness.FindById(Convert.ToInt32(id));
                if (Saida == null)
                    return NotFound("Saida não encontrada");

                return Ok(Saida);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("data", Name = "FindByDataSaida")]
        public async Task<IActionResult> FindByData(int dia, int mes, int ano)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(dia)) || string.IsNullOrEmpty(Convert.ToString(mes)) || string.IsNullOrEmpty(Convert.ToString(ano)))
                    return BadRequest(ModelState);

                var saidas = await _saidaEstoqueBusiness.FindByData(dia, mes, ano);
                if (saidas.Count.Equals(0))
                    return NotFound("Nenhuma saida encontrada correspondente com a data solicitada!");

                return Ok(saidas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("material", Name = "FindByMaterialSaida")]
        public async Task<IActionResult> FindByMaterial(string material)
        {
            try
            {
                if (string.IsNullOrEmpty(material))
                    return BadRequest(ModelState);

                var saidas = await _saidaEstoqueBusiness.FindByMaterial(material);
                if (saidas.Count.Equals(0))
                    return NotFound("Nenhuma saida encontrada correspondente com o material solicitado!");

                return Ok(saidas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("quantidade", Name = "FindQtdRetiradaByMaterial")]
        public async Task<IActionResult> FindQtdRetiradaByMaterial(string material)
        {
            try
            {
                if (string.IsNullOrEmpty(material))
                    return BadRequest(ModelState);

                var qtdsaidas =  _saidaEstoqueBusiness.FindQtdRetiradaByMaterial(material);
                
                if (qtdsaidas.Equals(0))
                    return NotFound("Nenhuma retirada encontrada correspondente com o material solicitado!");

                return Ok("Quantidade total retirada: " + qtdsaidas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateSaida")]
        public async Task<IActionResult> Create([FromBody]SaidaEstoque saida)
        {
            try
            {
                if (!ModelState.IsValid || saida == null)
                    return BadRequest(ModelState);

                var newsaida = await _saidaEstoqueBusiness.Create(saida);
                return CreatedAtRoute("FindByIdSaida", new { id = newsaida.Id }, newsaida);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateSaida")]
        public async Task<IActionResult> Update(SaidaEstoque saida)
        {
            try
            {
                if (saida == null)
                    return BadRequest("Saida nula");

                var putSaida = await _saidaEstoqueBusiness.Update(saida);
                return Ok(putSaida);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteSaida")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _saidaEstoqueBusiness.Delete(id);
                return Ok("Item deletado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion
    }

}

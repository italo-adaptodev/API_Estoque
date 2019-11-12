using Estoque.Business.interfaces;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estoque.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("entradaestoque")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EntradaEstoqueController : ControllerBase
    {
        private IEntradaEstoqueBusiness _entradaEstoqueBusiness;

        public EntradaEstoqueController(IEntradaEstoqueBusiness entradaEstoqueBusiness)
        {
            _entradaEstoqueBusiness = entradaEstoqueBusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllEntradas")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var entradas = await _entradaEstoqueBusiness.FindAll();
                if (entradas.Count > 0)
                    
                    return Ok(entradas);

                return NotFound("Nenhuma entrada encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("entrada/{id}", Name = "FindByIdEntrada")]
        public async Task<IActionResult> FindById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var entrada = await _entradaEstoqueBusiness.FindById(Convert.ToInt32(id));
                if (entrada == null)
                    return NotFound("Entrada não encontrada");

                return Ok(entrada);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("data", Name = "FindByDataEntrada")]
        public async Task<IActionResult> FindByData(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return BadRequest(ModelState);

                DateTime asDate = DateTime.Parse(data);
                
                var entradas = await _entradaEstoqueBusiness.FindByData(asDate);
                if (entradas.Count.Equals(0))
                    return NotFound("Nenhuma entrada encontrada correspondente com a data solicitada!");

                return Ok(entradas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("material/{material}", Name = "FindByMaterialEntrada")]
        public async Task<IActionResult> FindByMaterial(string material)
        {
            try
            {
                if (string.IsNullOrEmpty(material))
                    return BadRequest(ModelState);

                var entradas = await _entradaEstoqueBusiness.FindByMaterial(material);
                if (entradas.Count.Equals(0))
                    return NotFound("Nenhuma entrada encontrada correspondente com o material solicitado!");

                return Ok(entradas);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        #endregion

        #region POST
        [HttpPost(Name = "CreateEntrada")]
        public async Task<IActionResult> Create([FromBody]EntradaEstoque entrada)
        {
            try
            {
                if (!ModelState.IsValid || entrada == null)
                    return BadRequest(ModelState);

                var newentrada = await _entradaEstoqueBusiness.Create(entrada);
                return CreatedAtRoute("FindByIdEntrada", new { id = newentrada.Id }, newentrada);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateEntrada")]
        public async Task<IActionResult> Update(EntradaEstoque entrada)
        {
            try
            {
                if (entrada == null)
                    return BadRequest("Entrada nula");

                var putEntrada = await _entradaEstoqueBusiness.Update(entrada);
                return Ok(putEntrada);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteEntrada")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _entradaEstoqueBusiness.Delete(id);
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

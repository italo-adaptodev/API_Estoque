using Estoque.Business.interfaces;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estoque.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ControllerName("material")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MaterialController : ControllerBase
    {
        private IMaterialBusiness _materialBusiness;

        public MaterialController(IMaterialBusiness materialBusiness)
        {
            _materialBusiness = materialBusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllMateriais")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var materiais = await _materialBusiness.FindAll();
                if (materiais.Count > 0)
                    return Ok(materiais);

                return NotFound("Nenhum material encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("material/{id}", Name = "GetByIdMaterial")]
        public async Task<IActionResult> FindById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var material = await _materialBusiness.FindById(Convert.ToInt32(id));
                if (material == null)
                    return NotFound("Material não encontrado");

                return Ok(material);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }


        [HttpGet("{descricao}", Name = "FindMaterialByDescricao")]
        public async Task<IActionResult> FindMaterialByDescricao(string descricao)
        {
            try
            {
                if (string.IsNullOrEmpty(descricao))
                    return BadRequest(ModelState);

                var material = await _materialBusiness.FindMaterialByDescricao(descricao);
                if (material.Count.Equals(0))
                    return NotFound("Nenhum material foi encontrado correspondente com a descrição !");

                return Ok(material);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("tipo/{tipo}", Name = "FindMaterialByTipo")]
        public async Task<IActionResult> FindMaterialByTipo(string tipo)
        {
            try
            {
                if (string.IsNullOrEmpty(tipo))
                    return BadRequest(ModelState);

                var material = await _materialBusiness.FindMaterialByTipoMaterial(tipo);
                if (material.Count.Equals(0))
                    return NotFound("Nenhum material foi encontrado correspondente ao tipo!");

                return Ok(material);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateMaterial")]
        public async Task<IActionResult> Create([FromBody]Material material)
        {
            try
            {
                if (!ModelState.IsValid || material == null)
                    return BadRequest(ModelState);

                var newmaterial = await _materialBusiness.Create(material);
                return CreatedAtRoute("GetByIdMaterial", new { id = newmaterial.Id }, newmaterial);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateMaterial")]
        public async Task<IActionResult> Update(Material material)
        {
            try
            {
                if (material == null)
                    return BadRequest("Entrada nula");

                var putMaterial = await _materialBusiness.Update(material);
                return Ok(putMaterial);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteMaterial")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _materialBusiness.Delete(id);
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

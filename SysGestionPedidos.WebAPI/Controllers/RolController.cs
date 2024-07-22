using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionPedidos.BL;
using SysGestionPedidos.DAL;
using SysGestionPedidos.EN;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace SysGestionPedidos.WebAPI.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet(Name = "GetRoles")]
        public async Task<List<Rol>> Get()
        {
            //Investigar response http (404,200,500,501)
            var listaroles = await RolDAL.ObtenerTodosAsync();
            if (listaroles.Count >= 1)
            {
                return listaroles;
            }
            else
            {
                return new List<Rol>();
            }
        }
        [HttpPost(Name = "PostRoles")]
        public async Task<int> Post(Rol pRol)
        {
            if (pRol.Id >= 0)
            {
                int resultado = await RolDAL.CrearAsync(pRol);
                return resultado;
            }
            else
            {
                return 0;
            }

        }

        [HttpPut(Name = "PutRoles")]
        public async Task<int> Put(int id, [FromBody] Rol pRol)
        {

            if (pRol.Id >= 0)
            {
                int resultado = await RolDAL.ModificarAsync(pRol);
                return resultado;
            }
            else
            {
                return 0;
            }

        }

        [HttpDelete(Name = "DeleteRoles")]
        public async Task<int> Delete(int id, Rol pRol)
        {
            if (pRol.Id >= 0)
            {
               
                int resultado = await RolDAL.EliminarAsync(pRol);
                return resultado;
            }else
            {
                return 0;
            }
               
        }
    }
}

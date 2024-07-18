using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysGestionPedidos.DAL;
using SysGestionPedidos.EN;

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
    }
}

using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Proyecto")]
    public class ProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProyectosRepository _ProyectosRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProyectosRepository"></param>
        public ProyectoController(IProyectosRepository ProyectosRepository)
        {
            _ProyectosRepository = ProyectosRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("MostrarProyectos")]
        public ActionResult GetProyectos()
        {
            var ret = _ProyectosRepository.GetProyectos();
            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}

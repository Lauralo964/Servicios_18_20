using Servicios_18_20.Clases;
using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_18_20.Controllers
{
    [RoutePrefix("api/TipoProducto")]
    public class TipoProductoController : ApiController 
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TIpoPRoducto> ConsultarTodos()
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public TIpoPRoducto Consultar(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.Consultar(Codigo);
        }

        [HttpPost]
        [Route("Insertar")]

        public string Insertar([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto Tipoproducto = new clsTipoProducto();
            Tipoproducto.tipoProducto= tipoProducto;
            return Tipoproducto.Insertar();
        }
    }
}
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
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    { 
        [HttpGet]
        [Route ]
        public List<PRODucto> ConsultarTodos()
        { 
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public PRODucto Consultar(int Codigo)
        { 
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(Codigo);
        }

        [HttpGet]
        [Route("ConsultarXTipoProducto")]
        public List<PRODucto>ConsultarXTipoProducto(int TipoPorducto) 
        {
            clsProducto Prodcuto= new clsProducto();
            return Prodcuto.ConsultarXTipo(TipoPorducto);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODucto produto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = produto;
            return Producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Eliminar(Codigo);
        }

        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar([FromBody] int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ModificarActivo(Codigo, false);
        }

        [HttpPut]
        [Route("Activar")]
        public string Activar([FromBody] int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ModificarActivo(Codigo, true);
        }

    }
}
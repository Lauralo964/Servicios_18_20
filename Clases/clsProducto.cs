using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsProducto
    {
        private DBSuperEntities DBSuper = new DBSuperEntities();
        public PRODucto producto { get; set; }
        public List<PRODucto> ConsultarTodos() 
        { 
            return DBSuper.PRODuctoes
                .OrderBy(P=> P.Nombre)
                .ToList();
        }

        public PRODucto Consultar (int Codigo)
        {
            return DBSuper.PRODuctoes.FirstOrDefault(p=> p.Codigo == Codigo);
        }
        public List<PRODucto> ConsultarXTipo(int codigoTipoProducto)
        { 
            return DBSuper.PRODuctoes
                .Where(p=>p.CodigoTipoProducto==codigoTipoProducto)
                .OrderBy(p=>p.Nombre)
                .ToList();
        }
        public String Insertar() 
        { 
            try
            {
                DBSuper.PRODuctoes.Add(producto);
                DBSuper.SaveChanges();
                return "Se grabo el producto: " + producto.Nombre + "en la base de datos.";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public String Actualizar ()
        {
            try 
            {
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null) 
                {
                    return "El producto no esta definido en la base de datos";
                }
                DBSuper.PRODuctoes.AddOrUpdate(producto);
                DBSuper.SaveChanges();
                return "Se actualizo el producto: " + producto.Nombre + " en la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Eliminar (int Codigo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El producto no esta definido en la base de datos";
                }
                //Se remueve el objeto que se consultó, no el que se pasa en la propiedad de la clase
                DBSuper.PRODuctoes.Remove(prod);
                DBSuper.SaveChanges();
                return "Se elimino el producto: " + prod.Nombre + " en la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        public String ModificarActivo (int Codigo, bool activo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El producto no esta definido en la base de datos";
                }
                prod.Activo = activo;
                DBSuper.SaveChanges();
                if (activo)
                {
                    return "Se activo el producto: " + prod.Nombre;
                }
                else 
                { 
                    return "Se inactivo el producto: "+prod.Nombre;
                }
            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }

        }
    }
}
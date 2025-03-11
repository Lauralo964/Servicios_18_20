using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsTipoProducto
    {
        private DBSuperEntities DBSuper = new DBSuperEntities();
        public TIpoPRoducto tipoProducto { get; set; }
        public int Codigo { get; set; }

        public List<TIpoPRoducto> ConsultarTodos()
        {
            return DBSuper.TIpoPRoductoes
                .OrderBy(T => T.Nombre)
                .ToList();
        }

        public TIpoPRoducto Consultar(int Codigo)
        {
            return DBSuper.TIpoPRoductoes.FirstOrDefault(T => T.Codigo == Codigo);
        }

        public string Insertar()
        {
            try
            {
                DBSuper.TIpoPRoductoes.Add(tipoProducto);
                DBSuper.SaveChanges();
                return "Tipo de producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el tipo de producto" + ex.Message;
            }

        }
    }

}
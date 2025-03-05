using Microsoft.Ajax.Utilities;
using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
    public class clsEmpleado
    {
        //Objeto para gestionar los datos de los empleados con la base de datos
        private DBSuperEntities DBSuper = new DBSuperEntities();

        //Objeto tipo empleado para gestionar el crud en la base de datos
        public EMPLeado empleado { get; set; }


        public String Insertar() 
        {
            try
            {
                //Agregar un empleado a la lista del entity framework, se debe invocar el metodo SaveChanges para guardar los cambios
                //en la base de datos
                DBSuper.EMPLeadoes.Add(empleado);
                //Guarda los cambios en la base de datos
                DBSuper.SaveChanges();
                //Retorna mensaje de confirmacion
                return "Empleado insertado correctamente";
            }
            catch (Exception ex)
            {
                //Retorna un mensaje de error
                return "Error al insertar el empleado" + ex.Message;
            }

        }
        public String Actualizar() {
            //Antes de actualizar se deberia consultar si el dato ya existe para poder actualizarlo,
            //de lo contrario se deberia insertar o retornar un mensaje de error
            //Consultar el empleado
            try
            {
                EMPLeado empl = Consultar(empleado.Documento);
                if( empl == null )
                {
                    return "Empleado no existe";
                }
                DBSuper.EMPLeadoes.AddOrUpdate(empleado);
                DBSuper.SaveChanges();
                return "Empleado actualizado correctamente";
            } 
            catch (Exception ex) 
            {
                return ex.Message;
            }
            
        }
        public EMPLeado Consultar (String Documento)
        {
            //Expresiones lamda se convierten en objetos del tipo que se esat invocando
            //El metodo FirstOrDefault retorna el primer objeto que cumpla con la condicion que se escribe en la consulta
            EMPLeado empl = DBSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == Documento);
            return empl;
        }

        private bool validar(String Documento)
        {
            if (Consultar(Documento) == null)
            {
                return false;
            }
            else 
            { 
                return true;
            }
        }

        public String Eliminar () 
        {
            //primero se debe consultar
            try
            {
                EMPLeado empl = Consultar(empleado.Documento);
                if (empl == null)
                {
                    return "Empleado no existe"; //Retorna un mensaje de error
                }
                //Si el empleado existe se elimina
                DBSuper.EMPLeadoes.Remove(empl); //Elimina el empleado de la lista
                DBSuper.SaveChanges(); //Guarda los cambios en la base de datos
                return "Empleado eliminado correctamente"; //Retorna un mensaje de confirmación

            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado: " + ex.Message; //Retorna un mensaje de error
            }
        }

        public string EliminarXDocumento(string Documento)
        {
            //primero se debe consultar
            try
            {
                EMPLeado empl = Consultar(Documento);
                if (empl == null)
                {
                    return "Empleado no existe"; //Retorna un mensaje de error
                }
                //Si el empleado existe se elimina
                DBSuper.EMPLeadoes.Remove(empl); //Elimina el empleado de la lista
                DBSuper.SaveChanges(); //Guarda los cambios en la base de datos
                return "Empleado eliminado correctamente"; //Retorna un mensaje de confirmación

            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado: " + ex.Message; //Retorna un mensaje de error
            }

        }

        public List<EMPLeado> ConsultarTodos() 
        { 
            return DBSuper.EMPLeadoes
                .OrderBy (e => e.PrimerApellido)
                .ToList();
        }
    }
}
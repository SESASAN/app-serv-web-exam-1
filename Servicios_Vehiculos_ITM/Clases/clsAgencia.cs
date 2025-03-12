using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Servicios_Vehiculos_ITM.Models;

namespace Servicios_Vehiculos_ITM.Clases
{
    public class clsAgencia
    {
        private Db_Agencia_CarrosEntities dbagencia = new Db_Agencia_CarrosEntities();
        public Agencia agencia { get; set; }
        public string insertar()
        {
            try
            {
                dbagencia.Agencias.Add(agencia);
                dbagencia.SaveChanges();
                return "Agencia insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al ingresar al empleado" + ex.Message;
            }

        }
        public Agencia Consultar(int Id_Agencia)
        {
            Agencia ag = dbagencia.Agencias.FirstOrDefault(a => a.Id_Agencia == Id_Agencia);
            return ag;
        } 
        public string Actualizar()
        {
            Agencia ag = Consultar(agencia.Id_Agencia);
            if (ag == null)
            {
                return "Agencia inexistente";
            }
            dbagencia.Agencias.AddOrUpdate(agencia);
            dbagencia.SaveChanges();
            return "Actualizacion exitosa";
        }

        public string Eliminar()
        {
            Agencia ag = Consultar(agencia.Id_Agencia);
            if (ag == null)
            {
                return "Agencia inexistente";
            }
            dbagencia.Agencias.Remove(ag);
            dbagencia.SaveChanges();
            return "Eliminacion exitosa";
        }

        public List<Agencia> ConsultarTodos()
        {
            return dbagencia.Agencias.ToList();
        }
    }
}

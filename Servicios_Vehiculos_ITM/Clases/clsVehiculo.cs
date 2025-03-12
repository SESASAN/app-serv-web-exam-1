using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Servicios_Vehiculos_ITM.Models;

namespace Servicios_Vehiculos_ITM.Clases
{
    public class clsVehiculo
    {
        private Db_Agencia_CarrosEntities dbagencia = new Db_Agencia_CarrosEntities();
        public Vehiculo vehiculo { get; set; }
        public string insertar()
        {
            try
            {
                dbagencia.Vehiculos.Add(vehiculo);
                dbagencia.SaveChanges();
                return "Vehiculo insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al ingresar al empleado" + ex.Message;
            }

        }
        public Vehiculo Consultar(int Id_Vehiculo)
        {
            Vehiculo ve = dbagencia.Vehiculos.FirstOrDefault(a => a.Id_Vehiculo == Id_Vehiculo);
            return ve;
        }
        public string Actualizar()
        {
            Vehiculo ve = Consultar(vehiculo.Id_Vehiculo);
            if (ve == null)
            {
                return "Vehiculo inexistente";
            }
            dbagencia.Vehiculos.AddOrUpdate(vehiculo);
            dbagencia.SaveChanges();
            return "Actualizacion exitosa";
        }

        public string Eliminar()
        {
            Vehiculo ve = Consultar(vehiculo.Id_Vehiculo);
            if (ve == null)
            {
                return "Vehiculo inexistente";
            }
            dbagencia.Vehiculos.Remove(ve);
            dbagencia.SaveChanges();
            return "Eliminacion exitosa";
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return dbagencia.Vehiculos.ToList();
        }
    }
}

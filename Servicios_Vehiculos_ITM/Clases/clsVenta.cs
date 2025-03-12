using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Servicios_Vehiculos_ITM.Models;

namespace Servicios_Vehiculos_ITM.Clases
{
    public class clsVentas
    {
        private Db_Agencia_CarrosEntities dbagencia = new Db_Agencia_CarrosEntities();
        public Venta venta { get; set; }
        public string insertar()
        {
            try
            {
                dbagencia.Ventas.Add(venta);
                dbagencia.SaveChanges();
                return "Ventas insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al ingresar al empleado" + ex.Message;
            }

        }
        public Venta Consultar(int Id_Venta)
        {
            Venta ve = dbagencia.Ventas.FirstOrDefault(a => a.Id_Venta == Id_Venta);
            return ve;
        }
        public string Actualizar()
        {
            Venta ve = Consultar(venta.Id_Venta);
            if (ve == null)
            {
                return "Ventas inexistente";
            }
            dbagencia.Ventas.AddOrUpdate(venta);
            dbagencia.SaveChanges();
            return "Actualizacion exitosa";
        }

        public string Eliminar()
        {
            Venta ve = Consultar(venta.Id_Venta);
            if (ve == null)
            {
                return "Ventas inexistente";
            }
            dbagencia.Ventas.Remove(ve);
            dbagencia.SaveChanges();
            return "Eliminacion exitosa";
        }

        public List<Venta> ConsultarTodos()
        {
            return dbagencia.Ventas.ToList();
        }
    }
}

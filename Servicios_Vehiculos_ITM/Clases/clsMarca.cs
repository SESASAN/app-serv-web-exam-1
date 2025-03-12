using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Servicios_Vehiculos_ITM.Models;

namespace Servicios_Vehiculos_ITM.Clases
{
    public class clsMarca
    {
        private Db_Agencia_CarrosEntities dbagencia = new Db_Agencia_CarrosEntities();
        public Marca marca { get; set; }
        public string insertar()
        {
            try
            {
                dbagencia.Marcas.Add(marca);
                dbagencia.SaveChanges();
                return "Marca insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al ingresar al empleado" + ex.Message;
            }

        }
        public Marca Consultar(int Id_Marca)
        {
            Marca ma = dbagencia.Marcas.FirstOrDefault(a => a.Id_Marca == Id_Marca);
            return ma;
        }
        public string Actualizar()
        {
            Marca ma = Consultar(marca.Id_Marca);
            if (ma == null)
            {
                return "Marca inexistente";
            }
            dbagencia.Marcas.AddOrUpdate(marca);
            dbagencia.SaveChanges();
            return "Actualizacion exitosa";
        }

        public string Eliminar()
        {
            Marca ma = Consultar(marca.Id_Marca);
            if (ma == null)
            {
                return "Marca inexistente";
            }
            dbagencia.Marcas.Remove(ma);
            dbagencia.SaveChanges();
            return "Eliminacion exitosa";
        }

        public List<Marca> ConsultarTodos()
        {
            return dbagencia.Marcas.ToList();
        }
    }
}

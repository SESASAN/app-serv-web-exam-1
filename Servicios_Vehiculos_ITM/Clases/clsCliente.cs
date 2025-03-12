using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Servicios_Vehiculos_ITM.Models;

namespace Servicios_Vehiculos_ITM.Clases
{
    public class clsCliente
    {
        private Db_Agencia_CarrosEntities dbagencia = new Db_Agencia_CarrosEntities();
        public Cliente cliente { get; set; }
        public string insertar()
        {
            try
            {
                dbagencia.Clientes.Add(cliente);
                dbagencia.SaveChanges();
                return "Cliente insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al ingresar al empleado" + ex.Message;
            }

        }
        public Cliente Consultar(int Id_Cliente)
        {
            Cliente cli = dbagencia.Clientes.FirstOrDefault(a => a.Id_Cliente == Id_Cliente);
            return cli;
        }
        public string Actualizar()
        {
            Cliente cli = Consultar(cliente.Id_Cliente);
            if (cli == null)
            {
                return "Cliente inexistente";
            }
            dbagencia.Clientes.AddOrUpdate(cliente);
            dbagencia.SaveChanges();
            return "Actualizacion exitosa";
        }

        public string Eliminar()
        {
            Cliente cli = Consultar(cliente.Id_Cliente);
            if (cli == null)
            {
                return "Cliente inexistente";
            }
            dbagencia.Clientes.Remove(cli);
            dbagencia.SaveChanges();
            return "Eliminacion exitosa";
        }

        public List<Cliente> ConsultarTodos()
        {
            return dbagencia.Clientes.ToList();
        }
    }
}

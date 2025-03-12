using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using Servicios_Vehiculos_ITM.Models;
using Servicios_Vehiculos_ITM.Clases;

namespace Servicios_Vehiculos_ITM.Controllers
{
    [RoutePrefix("api/Vehiculos")]
    public class VehiculosController : ApiController
    {

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Vehiculo> ConsultarTodos()
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            return Vehiculo.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Vehiculo consultar(int Id_Vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            return Vehiculo.Consultar(Id_Vehiculo);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.vehiculo = vehiculo;
            return Vehiculo.insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.vehiculo = vehiculo;
            return Vehiculo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int Id_Vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            return Vehiculo.Eliminar(Id_Vehiculo);
        }
    }
    
}

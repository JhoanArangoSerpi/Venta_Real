using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;
using WSVenta.Models.Request;
using WSVenta.Models.Response;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                // Creamos el contexto donde vamos a crear todos los métodos que sirvan para hacer consultas.
                using (venta_realContext db = new venta_realContext())
                {
                    var lst = db.Clientes.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Datos correctamente recibidos.";
                    oRespuesta.Data = lst;
                }
            }catch (Exception ex)
            {
                oRespuesta.Mensaje=ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                // Usamos el contexto, instanciamos un nuevo objeto tipo Cliente y lo agregamos al contexto.
                using (venta_realContext db = new venta_realContext()) {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges(); // Con este método se ejecuta la query para agregar el objeto a la base de datos.
                    oRespuesta.Exito = 1;
                }
            }catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                // Usamos el contexto, instanciamos un nuevo objeto tipo Cliente y lo agregamos al contexto.
                using (venta_realContext db = new venta_realContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id); // Es como hacer un where a la base de datos.
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges(); // Con este método se ejecuta la query para agregar el objeto a la base de datos.
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Datos modificados exitosamente.";
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")] // Así se hace para recibir el parámetro por URL, como es la manera convencional.
        public IActionResult Delete(long Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                // Usamos el contexto, instanciamos un nuevo objeto tipo Cliente y lo agregamos al contexto.
                using (venta_realContext db = new venta_realContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id); // Es como hacer un where a la base de datos.
                    db.Remove(oCliente);
                    db.SaveChanges(); // Con este método se ejecuta la query para agregar el objeto a la base de datos.
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Datos borrados exitosamente.";
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}

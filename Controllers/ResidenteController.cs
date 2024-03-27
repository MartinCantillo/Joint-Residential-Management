using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelResidente.Residente;
using ModelsReporteAnomalias.ReporteAnomalia;
using ModelsUser.Usern;
using Mysqlx;
using RepositoriesIReporteAnomalia;
using RepositoriesIResidente.IResidente;

namespace ResidenteController
{

    [ApiController]
    [Route("[controller]")]
    public class ResidenteController : ControllerBase
    {
        public readonly IResidente _IResidente;
        public readonly IReporteAnomalia _IReporteAnomalia;

        public ResidenteController(IResidente _IResidente, IReporteAnomalia _IReporteAnomalia)
        {
            this._IResidente = _IResidente;
            this._IReporteAnomalia = _IReporteAnomalia;
        }

        [HttpPost("/SaveResidente")]
        public IActionResult SaveResidente(Residente residente)
        {
            if (residente.Num_telefono == "" || residente.Nombre_residente == "" || residente.Num_apartamento == "" || residente.Usuario == 0)
            {

                return BadRequest("Por favor verifica los datos ");
            }
            else
            {
                try
                {
                    this._IResidente.SaveResidente(residente);
                    return Ok();
                }
                catch (System.Exception)
                {

                    return BadRequest("Error del servidor");
                }

            }

        }

        //  [Authorize(Roles = "User")]
        [HttpPost("SaveAnomalia")]
        public IActionResult SaveAnomalia([FromBody] ReporteAnomalia reporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Por favor verifica los datos");
            }
            else
            {
                try
                {
                    this._IReporteAnomalia.SaveReporte(reporte);
                    return Accepted("Reporte guardado con exito");
                }
                catch (System.Exception)
                {

                    return BadRequest("Error del servidor");
                }
            }

        }


    }

}
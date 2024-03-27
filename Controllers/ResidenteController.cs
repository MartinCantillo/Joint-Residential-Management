using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelResidente.Residente;
using Mysqlx;
using RepositoriesIResidente.IResidente;

namespace ResidenteController
{

    [ApiController]
    [Route("[controller]")]
    public class ResidenteController : ControllerBase
    {
        public readonly IResidente _IResidente;

        public ResidenteController(IResidente _IResidente)
        {
            this._IResidente = _IResidente;
        }

        [HttpPost("/SaveResidente")]
        public IActionResult SaveResidente(Residente residente)
        {
            if (residente.Num_telefono == "" || residente.Nombre_residente == ""  || residente.Num_apartamento == "")
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


    }

}
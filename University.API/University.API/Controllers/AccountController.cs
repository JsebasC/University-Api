using Microsoft.AspNet.Identity.Owin;
using System.Web.Http;
using System.Web.UI.WebControls;
using University.BL.DTOs;

namespace University.API.Controllers
{
    [AllowAnonymous] //no requiere autenticación
    public class AccountController : ApiController
    {

        /// <summary>
        /// Metodo encargado de realizar la autenticación
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isCredentialValid = (loginDTO.Password == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);
                return Ok(token);
            }
            else
                return Unauthorized(); //status code 401                            
        }


    }
}

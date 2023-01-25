using Microsoft.Owin;
using Owin;
using University.BL.Data;

[assembly: OwinStartup(typeof(University.API.Startup))]

namespace University.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //Por un contexto cree la instancia de lo que necesitamos, no hay necesidad de siempre inicializar el objeto y por cada request guarda la instancia
            //sigue el modelo de singleton
            app.CreatePerOwinContext(UniversityContext.Create);            
        }
    }
}

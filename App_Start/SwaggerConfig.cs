using System.Web.Http;
using WebActivatorEx;
using WsElevadores;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WsElevadores
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {                        
                        c.SingleApiVersion("v1", "WsElevadores");                        
                        c.IncludeXmlComments(GetXmlCommentsPath());                        
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }
        

        private static string GetXmlCommentsPath()
        {
            //throw new NotImplementedException();

            return System.AppDomain.CurrentDomain.BaseDirectory + @"bin\WsElevadores.xml";
        }
    }
}

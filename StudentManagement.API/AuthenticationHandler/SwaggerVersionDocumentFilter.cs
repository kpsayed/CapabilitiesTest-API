using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StudentManagement.API.AuthenticationHandler
{
    public class SwaggerVersionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var apiVersion = swaggerDoc.Info.Version;
            swaggerDoc.Components.SecuritySchemes.Clear();

            if (apiVersion == "v1")
            {
                swaggerDoc.Components.SecuritySchemes.Add("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Bearer Authentication with JWT Token"
                });
            }
        }
    }
}

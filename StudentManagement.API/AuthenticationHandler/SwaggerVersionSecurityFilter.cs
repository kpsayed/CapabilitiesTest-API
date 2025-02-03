using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StudentManagement.API.AuthenticationHandler
{
    public class SwaggerVersionSecurityFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiVersion = context.ApiDescription.GroupName;

            if (operation.Security == null)
                operation.Security = new List<OpenApiSecurityRequirement>();

            switch (apiVersion)
            {
                case "v1":
                    operation.Security.Add(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                    break;
                case "v2":
                    operation.Security.Add(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BasicAuth"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                    break;

                default:
                    operation.Security.Add(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                    break;
            }
        }
    }
}

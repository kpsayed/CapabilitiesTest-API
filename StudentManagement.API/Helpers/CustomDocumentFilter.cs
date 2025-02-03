using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StudentManagement.API.Helpers
{
    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var controllerOrder = new List<string>
        {
            "Students",  
            "FamilyMembers",
            "Nationalities"
        };

            var paths = swaggerDoc.Paths;

            var orderedPaths = paths
                .OrderBy(path =>
                {

                    var controllerName = path.Key.Split('/')[2];  

                    return controllerOrder.IndexOf(controllerName);
                })
                .ToDictionary(path => path.Key, path => path.Value);

            swaggerDoc.Paths.Clear();
            foreach (var path in orderedPaths)
            {
                swaggerDoc.Paths.Add(path.Key, path.Value);
            }
        }
    }

}






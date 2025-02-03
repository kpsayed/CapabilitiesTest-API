
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StudentManagement.API.AuthenticationHandler;
using StudentManagement.API.Helpers;
using StudentManagement.Application.Services;
using StudentManagement.Application.Services.Interfaces;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Persistance;
using StudentManagement.Persistance.Repositories;
var builder = WebApplication.CreateBuilder(args);
{
    ConfigurationManager configuration = builder.Configuration;

    //var logger = LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    builder.Services.AddDbContext<StudentManagementDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementSystem"));
    });

    builder.Services.AddApiVersioning(o =>
    {
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        o.ReportApiVersions = true;
        o.ApiVersionReader = ApiVersionReader.Combine(
            new MediaTypeApiVersionReader("ver"));

    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "cors",
          builder =>
          {
              builder.WithOrigins("*")
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .SetIsOriginAllowedToAllowWildcardSubdomains()
              .AllowAnyHeader();
          });
    });


    #region set jwt key
    var _key = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx";
    var _issuer = "AWQAFSSO";
    var _audience = "AWQAFClients";

    var _UserJwt_Key = "QVdRQUZTU09fREVWRUxPUEVEQllfU0FZRURLQUxMRVRUVVBBTEFN";
    var _UserJwt_audience = "Awqaf_EndUsers";

    //builder.Services.AddJwtAuthentication(builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:Audience"], builder.Configuration["Jwt:Key"]);
    builder.Services.AddJwtAuthentication(_issuer, _audience, _key, _UserJwt_Key, _UserJwt_audience);
    #endregion



    builder.Services.AddVersionedApiExplorer(
             options =>
             {
                 options.GroupNameFormat = "'v'VVV";
                 options.SubstituteApiVersionInUrl = true;
             });

    #region swagger
    builder.Services.AddSwaggerGen(options =>
    {
        options.DocumentFilter<CustomDocumentFilter>();
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Management System API", Version = "v1", Description = "Security with JWT-Authentication" });
        options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        options.DocumentFilter<SwaggerVersionDocumentFilter>();
        options.OperationFilter<SwaggerVersionSecurityFilter>();
        options.DocInclusionPredicate((version, apiDescription) =>
        {
            return apiDescription.GroupName == version;
        });
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddApiVersioning(o =>
    {
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.ReportApiVersions = true;
        o.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"));
    });
    #endregion


    builder.Services.AddAuthorization();
    builder.Services.Configure<FormOptions>(o =>
    {
        o.ValueLengthLimit = int.MaxValue;
        o.MultipartBodyLengthLimit = int.MaxValue;
        o.MemoryBufferThreshold = int.MaxValue;
    });



    //builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<IStudentServices, StudentServices>();
    builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();
    builder.Services.AddScoped<IFamilyServices, FamilyServices>();
    builder.Services.AddScoped<IMasterRepository, MasterRepository>();
    builder.Services.AddScoped<IMastersServices, MastersServices>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddRouting();
}


var app = builder.Build();
{
    var environment = app.Environment.EnvironmentName;
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseDeveloperExceptionPage();
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseStaticFiles();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("v1/swagger.json", "WebAPI V1");
            options.DocumentTitle = "Student Management WEB APIs";
        });
    }

    if (app.Environment.IsProduction())
    {

        app.UseStaticFiles();
        app.UseDeveloperExceptionPage();
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("cors");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}

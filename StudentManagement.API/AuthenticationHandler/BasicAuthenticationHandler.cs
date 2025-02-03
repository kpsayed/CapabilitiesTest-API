
using Awqaf.API.Gateway.Common.Encryption;
using Awqaf.Website.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Web.Http.Controllers;

namespace Awqaf.API.Gateway.AuthenticationHandler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration Configuration;
        private readonly IHajjServices _hajjRepository;       

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder, IHajjServices hajjRepository,
            ISystemClock clock
        , IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            _hajjRepository = hajjRepository;
            Configuration = configuration;            
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring("Basic ".Length).Trim();

                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                //var decryptedAuthenticationToken = Crypto.Decrypt(credentialstring);
                if (string.IsNullOrEmpty(credentialstring))
                {
                    Response.StatusCode = 401;
                    Response.Headers.Add("WWW-Authenticate", "Basic realm=\" https://MobileAppApi.awqaf.gov.ae\"");
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
                else
                {
                    var credentials = credentialstring.Split(':');
                    var APIConsumer = Utilities.CommonHelper.GetAPIConsumer(credentials[0], credentials[1]);
                    if (APIConsumer != null)
                    {
                        //var credentialsUserName = Configuration["BasicAuthorizationCredential:UserName"];// Read it from DB
                        //var credentialsPassword = Configuration["BasicAuthorizationCredential:Password"];
                        var credentialsUserName = APIConsumer.ClientUsername;// 
                        var credentialsPassword = APIConsumer.ClientSecret;
                        if (credentials[0] == credentialsUserName && credentials[1] == credentialsPassword)
                        {
                            var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "API Client") };
                            var identity = new ClaimsIdentity(claims, "Basic");
                            var claimsPrincipal = new ClaimsPrincipal(identity);
                            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                        }
                    }
                    //_hajjRepository.InsertAuthorizeLogs("Authorize", "Invalid Credentials : Username: " + credentials[0].ToString() + " Password: " + credentials[1].ToString());
                    Response.StatusCode = 401;
                    Response.Headers.Add("WWW-Authenticate", "Basic realm=\"test-web2-app\"");
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
            }
            else
            {
                Response.StatusCode = 401;
                Response.Headers.Add("WWW-Authenticate", "Basic realm=\"test-web2-app\"");
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }
    }
}

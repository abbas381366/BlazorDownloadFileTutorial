using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BlazorApp31.DownloadTokenService;

namespace BlazorApp31
{
    //Download?id=dfdfg
    [Route("[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        DownloadTokenService tokenService;

        public DownloadController(DownloadTokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            DownloadToken? token = tokenService.DownloadTokens
                .SingleOrDefault(q => q.Guid == id);
            try
            {
                if (token == null)
                {
                    return NotFound();
                }
                return File(token.Stream, "application/octet-stream", token.FakeName);
            }
            finally
            {
                tokenService.DownloadTokens.Remove(token);
            }
        }
    }
}

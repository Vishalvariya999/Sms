using Application.Commands.Standards;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace Sms.Odata
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ODataControllerBase
    {
        [EnableQuery]
        [HttpGet]
        public async Task<IQueryable<Standard>> Get() =>
                await Mediator.Send(new GetStandardQueryable());

        // GET: odata/Permission(5)
        [HttpGet("{key:int}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Get([FromODataUri] int key) =>
            Ok(await Mediator.Send(new GetStandardQuery { Key = key }));
    }
}

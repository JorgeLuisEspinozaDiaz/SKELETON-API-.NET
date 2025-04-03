using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NovaCore.Service.Almacen.Application.Queries.Test;

namespace NovaCore.Service.Almacen.Api.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly IMediator _mediator;
        public TestController(ILogger<TestController> logger, IMediator _mediator)
        {
            _logger = logger;
            this._mediator = _mediator;
        }

        [HttpGet("obtener")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<TestDTO>>> Obtener()
        {
            var result = await _mediator.Send(new TestQuery());
            return Ok(result);
        }
    }
}
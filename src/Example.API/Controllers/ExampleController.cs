using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.Example.Models.Request;
using Example.Application.Example.Services;
using Example.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : BaseController
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService, INotification notification): base(notification)
        {
            _exampleService = exampleService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ExampleCreateRequest request) => Response(await _exampleService.CreateAsync(request).ConfigureAwait(false));

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Response(await _exampleService.GetAllAsync().ConfigureAwait(false));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync([FromRoute]int id) => Response(await _exampleService.GetOneAsync(id).ConfigureAwait(false));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody]ExampleUpdateRequest request) => Response(await _exampleService.UpdateAsync(id, request).ConfigureAwait(false));
    }
}

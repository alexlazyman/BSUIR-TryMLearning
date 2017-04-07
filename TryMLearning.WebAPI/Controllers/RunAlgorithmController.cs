using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.Controllers
{
    public class RunAlgorithmController : ApiController
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly IAlgorithmSessionService _algorithmSessionService;

        public RunAlgorithmController(
            IAlgorithmService algorithmService,
            IAlgorithmSessionService algorithmSessionService)
        {
            _algorithmService = algorithmService;
            _algorithmSessionService = algorithmSessionService;
        }

        // GET api/runalgorithm/5
        [SwaggerOperation("Get algorithm session by id")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<AlgorithmSession> Get(int id)
        {
            return await _algorithmSessionService.GetAlgorithmSessionAsync(id);
        }

        // POST api/runalgorithm
        [SwaggerOperation("Run algorithm")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<AlgorithmSession> Post([FromBody] AlgorithmForm algorithmForm)
        {
            return await _algorithmService.RunAlgorithmAsync(algorithmForm);
        }
    }
}

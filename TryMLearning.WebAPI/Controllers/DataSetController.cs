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
    [RoutePrefix("api/dataset")]
    public class DataSetControllerController : ApiController
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly IAlgorithmSessionService _algorithmSessionService;

        public DataSetControllerController(
            IAlgorithmService algorithmService,
            IAlgorithmSessionService algorithmSessionService)
        {
            _algorithmService = algorithmService;
            _algorithmSessionService = algorithmSessionService;
        }

        // GET api/algorithm/5
        [Route("{id:int}")]
        [HttpGet]
        [SwaggerOperation("Get algorithm by id")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<Algorithm> GetAlgorithm(
            [FromUri(Name = "id")] int algorithmId)
        {
            return await _algorithmService.GetAlgorithmAsync(algorithmId);
        }

        // POST api/algorithm
        [Route("")]
        [HttpPost]
        [SwaggerOperation("Create algorithm")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<Algorithm> CreateAlgorithm(
            [FromBody] Algorithm algorithm)
        {
            return await _algorithmService.AddAlgorithmAsync(algorithm);
        }

        // DELETE api/algorithm/5
        [Route("{id:int}")]
        [HttpDelete]
        [SwaggerOperation("Delete algorithm")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task DeleteAlgorithm(
            [FromUri(Name = "id")] int algorithmId)
        {
            await _algorithmService.DeleteAlgorithmAsync(algorithmId);
        }
    }
}

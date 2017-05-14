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
    [RoutePrefix("api/algorithm")]
    public class AlgorithmController : ApiController
    {
        private readonly IAlgorithmService _algorithmService;

        public AlgorithmController(
            IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        // GET api/algorithm/5
        [Route("{algorithmId:int}")]
        [HttpGet]
        [SwaggerOperation("Get algorithm by id")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<Algorithm> GetAlgorithmAsync(int algorithmId)
        {
            return await _algorithmService.GetAlgorithmAsync(algorithmId);
        }

        // GET api/algorithm
        [Route]
        [HttpGet]
        [SwaggerOperation("Get all algorithms")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<Algorithm>))]
        [Authorize]
        public async Task<List<Algorithm>> GetAllAlgorithmsAsync()
        {
            return await _algorithmService.GetAllAlgorithmsAsync();
        }

        // POST api/algorithm
        [Route("")]
        [HttpPost]
        [SwaggerOperation("Create algorithm")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<Algorithm> CreateAlgorithmAsync(Algorithm algorithm)
        {
            return await _algorithmService.AddAlgorithmAsync(algorithm);
        }

        // PUT api/algorithm
        [Route("")]
        [HttpPut]
        [SwaggerOperation("Update algorithm")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            return await _algorithmService.UpdateAlgorithmAsync(algorithm);
        }

        // DELETE api/algorithm/5
        [Route("{algorithmId:int}")]
        [HttpDelete]
        [SwaggerOperation("Delete algorithm")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task DeleteAlgorithmAsync(int algorithmId)
        {
            await _algorithmService.DeleteAlgorithmAsync(algorithmId);
        }
    }
}

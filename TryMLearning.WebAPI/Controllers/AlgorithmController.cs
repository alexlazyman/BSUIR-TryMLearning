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
    public class AlgorithmController : ApiController
    {
        private readonly IAlgorithmService _algorithmService;

        public AlgorithmController(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        // GET api/algorithm/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Algorithm> Get(int id)
        {
            return await _algorithmService.GetAlgorithmAsync(id);
        }

        // POST api/algorithm
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<Algorithm> Post([FromBody] Algorithm algorithm)
        {
            return await _algorithmService.AddAlgorithmAsync(algorithm);
        }

        // PUT api/algorithm
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Algorithm> Put([FromBody] Algorithm algorithm)
        {
            return await _algorithmService.UpdateAlgorithmAsync(algorithm);
        }

        // DELETE api/algorithm/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task Delete(int id)
        {
            await _algorithmService.DeleteAlgorithmAsync(id);
        }
    }
}

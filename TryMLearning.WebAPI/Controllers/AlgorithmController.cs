using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
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

        [HttpGet]
        [Route("{algorithmId:int}")]
        public async Task<Algorithm> GetAlgorithmAsync(int algorithmId)
        {
            return await _algorithmService.GetAlgorithmAsync(algorithmId);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Algorithm>> GetAllAlgorithmsAsync()
        {
            return await _algorithmService.GetAllAlgorithmsAsync();
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<Algorithm> CreateAlgorithmAsync(Algorithm algorithm)
        {
            return await _algorithmService.AddAlgorithmAsync(algorithm);
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        public async Task<Algorithm> UpdateAlgorithmAsync(Algorithm algorithm)
        {
            return await _algorithmService.UpdateAlgorithmAsync(algorithm);
        }

        [Authorize]
        [HttpDelete]
        [Route("{algorithmId:int}")]
        public async Task DeleteAlgorithmAsync(int algorithmId)
        {
            await _algorithmService.DeleteAlgorithmAsync(algorithmId);
        }
    }
}

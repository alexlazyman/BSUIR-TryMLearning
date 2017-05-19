using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/estimation")]
    public class EstimationController : ApiController
    {
        private readonly IAlgorithmEstimationService _algorithmEstimationService;

        public EstimationController(
            IAlgorithmEstimationService algorithmEstimationService)
        {
            _algorithmEstimationService = algorithmEstimationService;
        }

        [HttpGet]
        [Route("{algorithmEstimationId:int}")]
        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            return await _algorithmEstimationService.GetAlgorithmEstimationAsync(algorithmEstimationId);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<AlgorithmEstimation>> GetAllAlgorithmEstimationsAsync()
        {
            return await _algorithmEstimationService.GetAllAlgorithmEstimationsAsync();
        }

        [HttpDelete]
        [Route("{algorithmEstimationId:int}")]
        public async Task DeleteAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            await _algorithmEstimationService.DeleteAlgorithmEstimationAsync(algorithmEstimationId);
        }
    }
}

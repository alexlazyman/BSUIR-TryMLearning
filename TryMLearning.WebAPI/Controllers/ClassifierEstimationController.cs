using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/estimation/classifier")]
    public class ClassifierEstimationController : ApiController
    {
        private readonly IAlgorithmEstimationService _algorithmEstimationService;

        public ClassifierEstimationController(
            IAlgorithmEstimationService algorithmEstimationService)
        {
            _algorithmEstimationService = algorithmEstimationService;
        }

        [HttpPost]
        [Route("")]
        public async Task<AlgorithmEstimation> EstimateAlgorithmAsync(AlgorithmEstimation algorithmEstimation)
        {
            return await _algorithmEstimationService.RunEstimationAsync(algorithmEstimation);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("result")]
        public async Task<List<EstimateResponse>> GetClassifierEstimationResultAsync(
            [FromUri(Name = "id")] int algorithmEstimationId,
            [FromUri(Name = "e")] string estimates)
        {
            var estimateRequests = JsonConvert.DeserializeObject<List<EstimateRequest>>(estimates);

            return await _algorithmEstimationService.GetClassifierEstimationResultAsync(algorithmEstimationId, estimateRequests);
        }
    }
}

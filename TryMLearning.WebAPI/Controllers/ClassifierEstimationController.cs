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
        private readonly IEstimationService _estimationService;

        public ClassifierEstimationController(
            IEstimationService estimationService)
        {
            _estimationService = estimationService;
        }

        [HttpPost]
        [Route("")]
        public async Task<Estimation> EstimateAlgorithmAsync(Estimation estimation)
        {
            return await _estimationService.RunEstimationAsync(estimation);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("result")]
        public async Task<List<EstimateResult>> GetClassifierEstimationResultAsync(
            [FromUri(Name = "id")] int estimationId,
            [FromUri(Name = "e")] string estimates)
        {
            var estimateRequests = JsonConvert.DeserializeObject<List<EstimateRequest>>(estimates);

            return await _estimationService.GetClassifierEstimationResultAsync(estimationId, estimateRequests);
        }
    }
}

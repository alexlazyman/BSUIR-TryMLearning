using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

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

        [HttpGet]
        [Route("{algorithmEstimationId:int}")]
        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            return await _algorithmEstimationService.GetAlgorithmEstimationAsync(algorithmEstimationId);
        }

        [HttpGet]
        [Route("result")]
        public async Task<ClassifierEstimationResult> GetClassifierEstimationResultAsync([FromUri] ClassifierEstimationResultRequest request)
        {
            return await _algorithmEstimationService.GetClassifierEstimationResultAsync(request);
        }
    }
}

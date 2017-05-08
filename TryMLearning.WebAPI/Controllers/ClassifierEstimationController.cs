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
using TryMLearning.Model.MachineLearning.EstimationResults.Classifier;

namespace TryMLearning.WebAPI.Controllers
{
    [RoutePrefix("api/estimation/classifier")]
    public class ClassifierEstimationController : ApiController
    {
        private readonly IAlgorithmEstimationService _algorithmEstimationService;

        public ClassifierEstimationController(
            IAlgorithmEstimationService algorithmEstimationService)
        {
            _algorithmEstimationService = algorithmEstimationService;
        }

        // POST api/estimation/classifier
        [Route("")]
        [HttpPost]
        [SwaggerOperation("Estimate algorithm")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<AlgorithmEstimation> EstimateAlgorithmAsync(AlgorithmEstimation algorithmEstimation)
        {
            return await _algorithmEstimationService.RunEstimationAsync(algorithmEstimation);
        }

        // GET api/estimation/classifier/5
        [Route("{algorithmEstimationId:int}")]
        [HttpGet]
        [SwaggerOperation("Get classifier estimation")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<AlgorithmEstimation> GetAlgorithmEstimationAsync(int algorithmEstimationId)
        {
            return await _algorithmEstimationService.GetAlgorithmEstimationAsync(algorithmEstimationId);
        }

        // GET api/estimation/result
        [Route("result")]
        [HttpGet]
        [SwaggerOperation("Get classifier estimation result")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<ClassifierEstimationResult> GetClassifierEstimationResultAsync(ClassifierEstimationResultRequest request)
        {
            return await _algorithmEstimationService.GetClassifierEstimationResultAsync(request);
        }
    }
}

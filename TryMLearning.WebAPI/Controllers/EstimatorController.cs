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
    [RoutePrefix("api/estimator")]
    public class EstimatorController : ApiController
    {
        private readonly IEstimatorService _estimatorService;

        public EstimatorController(
            IEstimatorService estimatorService)
        {
            _estimatorService = estimatorService;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Estimator>> GetAllAlgorithmsAsync()
        {
            return await _estimatorService.GetAllEstimatorsAsync();
        }
    }
}

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
        private readonly IEstimationService _estimationService;

        public EstimationController(
            IEstimationService estimationService)
        {
            _estimationService = estimationService;
        }

        [HttpGet]
        [Route("{estimationId:int}")]
        public async Task<Estimation> GetEstimationAsync(int estimationId)
        {
            return await _estimationService.GetEstimationAsync(estimationId);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Estimation>> GetAllEstimationsAsync()
        {
            return await _estimationService.GetAllEstimationsAsync();
        }

        [HttpDelete]
        [Route("{estimationId:int}")]
        public async Task DeleteEstimationAsync(int estimationId)
        {
            await _estimationService.DeleteEstimationAsync(estimationId);
        }
    }
}

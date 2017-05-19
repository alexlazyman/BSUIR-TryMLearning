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
    }
}

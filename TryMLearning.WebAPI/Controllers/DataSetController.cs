using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger.Annotations;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.Controllers
{
    [RoutePrefix("api/dataset")]
    public class DataSetController : ApiController
    {
        private readonly IDataSetService _dataSetService;
        private readonly IDataSetSampleService<ClassificationDataSetSmaple> _classificationDataSetSampleService;

        public DataSetController(
            IDataSetService dataSetService,
            IDataSetSampleService<ClassificationDataSetSmaple> classificationDataSetSampleService)
        {
            _dataSetService = dataSetService;
            _classificationDataSetSampleService = classificationDataSetSampleService;
        }

        // GET api/dataset/5
        [Route("{dataSetId:int}")]
        [HttpGet]
        [SwaggerOperation("Get data set by id")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(DataSet))]
        public async Task<DataSet> GetDataSetAsync(int dataSetId)
        {
            return await _dataSetService.GetDataSetAsync(dataSetId);
        }

        // POST api/dataset
        [Route]
        [HttpPost]
        [SwaggerOperation("Create data set")]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(DataSet))]
        public async Task<DataSet> CreateDataSetAsync(DataSet dataSet)
        {
            return await _dataSetService.AddDataSetAsync(dataSet);
        }

        // PUT api/dataset
        [Route]
        [HttpPut]
        [SwaggerOperation("Update data set")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(DataSet))]
        public async Task<DataSet> UpdateDataSetAsync(DataSet dataSet)
        {
            return await _dataSetService.UpdateDataSetAsync(dataSet);
        }

        // DELETE api/dataset/5
        [Route("{dataSetId:int}")]
        [HttpDelete]
        [SwaggerOperation("Delete data set")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task DeleteDataSetAsync(int dataSetId)
        {
            await _dataSetService.DeleteDataSetAsync(dataSetId);
        }

        #region Classification Data Set Sample

        // GET api/dataset/5/sample/classification/0/10
        [Route("{dataSetId:int}/sample/classification/{start:int}/{count:int}")]
        [HttpGet]
        [SwaggerOperation("Get classification data set samples")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<ClassificationDataSetSmaple>))]
        public async Task<List<ClassificationDataSetSmaple>> GetClassificationDataSetSamplesAsync(int dataSetId, int start, int count)
        {
            var samples = await _classificationDataSetSampleService.GetDataSetSamplesAsync(dataSetId, start, count);

            return samples;
        }

        // POST api/dataset/5/sample/classification
        [Route("{dataSetId:int}/sample/classification")]
        [HttpPost]
        [SwaggerOperation("Create classification data set samples")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<ClassificationDataSetSmaple>))]
        public async Task<List<ClassificationDataSetSmaple>> AddClassificationDataSetSamplesAsync(int dataSetId, List<ClassificationDataSetSmaple> samples)
        {
            samples = await _classificationDataSetSampleService.AddDataSetSamplesAsync(dataSetId, samples);

            return samples;
        }

        // DELETE api/dataset/5/classification
        [Route("{dataSetId:int}/sample/classification")]
        [HttpDelete]
        [SwaggerOperation("Delete data set samples")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task DeleteClassificationDataSetSamplesAsync(int dataSetId, List<int> dataSetSampleIds)
        {
            await _classificationDataSetSampleService.DeleteDataSetSamplesAsync(dataSetId, dataSetSampleIds);
        }

        #endregion
    }
}

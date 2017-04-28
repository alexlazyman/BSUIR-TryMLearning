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
        private readonly ISampleService<ClassificationSample> _classificationSampleService;

        public DataSetController(
            IDataSetService dataSetService,
            ISampleService<ClassificationSample> classificationSampleService)
        {
            _dataSetService = dataSetService;
            _classificationSampleService = classificationSampleService;
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

        // GET api/dataset
        [Route]
        [HttpGet]
        [SwaggerOperation("Get all data sets")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<DataSet>))]
        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await _dataSetService.GetAllDataSetsAsync();
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
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<ClassificationSample>))]
        public async Task<List<ClassificationSample>> GetClassificationSamplesAsync(int dataSetId, int start, int count)
        {
            var samples = await _classificationSampleService.GetSamplesAsync(dataSetId, start, count);

            return samples;
        }

        // POST api/dataset/5/sample/classification
        [Route("{dataSetId:int}/sample/classification")]
        [HttpPost]
        [SwaggerOperation("Create classification data set samples")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<ClassificationSample>))]
        public async Task<List<ClassificationSample>> AddClassificationSamplesAsync(int dataSetId, List<ClassificationSample> samples)
        {
            samples = await _classificationSampleService.AddSamplesAsync(dataSetId, samples);

            return samples;
        }

        // DELETE api/dataset/5/classification
        [Route("{dataSetId:int}/sample/classification")]
        [HttpDelete]
        [SwaggerOperation("Delete data set samples")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task DeleteClassificationSamplesAsync(int dataSetId, List<int> sampleIds)
        {
            await _classificationSampleService.DeleteSamplesAsync(dataSetId, sampleIds);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;

namespace TryMLearning.WebAPI.Controllers
{
    [RoutePrefix("api/dataset")]
    public class DataSetController : ApiController
    {
        private readonly IDataSetService _dataSetService;
        private readonly ISampleService<ClassificationSample> _classificationSampleService;
        private readonly IClassAliasService _classAliasService;

        public DataSetController(
            IDataSetService dataSetService,
            ISampleService<ClassificationSample> classificationSampleService,
            IClassAliasService classAliasService)
        {
            _dataSetService = dataSetService;
            _classificationSampleService = classificationSampleService;
            _classAliasService = classAliasService;
        }

        [HttpGet]
        [Route("{dataSetId:int}")]
        public async Task<DataSet> GetDataSetAsync(int dataSetId)
        {
            return await _dataSetService.GetDataSetAsync(dataSetId);
        }

        [HttpGet]
        [Route("{dataSetId:int}/classes")]
        public async Task<List<ClassAlias>> GetClassAliasesAsync(int dataSetId)
        {
            return await _classAliasService.GetClassAliases(dataSetId);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await _dataSetService.GetAllDataSetsAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<DataSet> CreateDataSetAsync(DataSet dataSet)
        {
            return await _dataSetService.AddDataSetAsync(dataSet);
        }

        [HttpPut]
        [Route("")]
        public async Task<DataSet> UpdateDataSetAsync(DataSet dataSet)
        {
            return await _dataSetService.UpdateDataSetAsync(dataSet);
        }

        [HttpDelete]
        [Route("{dataSetId:int}")]
        public async Task DeleteDataSetAsync(int dataSetId)
        {
            await _dataSetService.DeleteDataSetAsync(dataSetId);
        }

        #region Classification Data Set Sample

        [HttpGet]
        [Route("{dataSetId:int}/sample/classification")]
        public async Task<List<ClassificationSample>> GetClassificationSamplesAsync(int dataSetId)
        {
            var samples = await _classificationSampleService.GetAllSamplesAsync(dataSetId);

            return samples;
        }

        [HttpPost]
        [Route("{dataSetId:int}/sample/classification")]
        public async Task<List<ClassificationSample>> AddClassificationSamplesAsync(int dataSetId, List<ClassificationSample> samples)
        {
            samples = await _classificationSampleService.AddSamplesAsync(dataSetId, samples);

            return samples;
        }

        [HttpDelete]
        [Route("{dataSetId:int}/sample/classification")]
        public async Task DeleteClassificationSamplesAsync(int dataSetId, List<int> sampleIds)
        {
            await _classificationSampleService.DeleteSamplesAsync(dataSetId, sampleIds);
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IClassificationDataSetSmapleDao
    {
        Task<List<ClassificationDataSetSmaple>> AddClassificationDataSetSmaplesAsync(List<ClassificationDataSetSmaple> classificationDataSetSmaples);

        Task<int> GetClassificationDataSetSmapleCountAsync(int dataSetId);

        Task<List<ClassificationDataSetSmaple>> GetClassificationDataSetSmaplesAsync(int dataSetId, int start, int count);

        Task DeleteClassificationDataSetSmapleAsync(ClassificationDataSetSmaple classificationDataSetSmaple);
    }
}
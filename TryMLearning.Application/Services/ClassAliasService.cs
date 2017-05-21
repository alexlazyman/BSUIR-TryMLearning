using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Application.Interface.Services;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Application.Services
{
    public class ClassAliasService : IClassAliasService
    {
        private readonly IClassAliasDao _classAliasDao;

        public ClassAliasService(
            IClassAliasDao classAliasDao)
        {
            _classAliasDao = classAliasDao;
        }

        public async Task<List<ClassAlias>> GetClassAliases(int dataSetId)
        {
            return await _classAliasDao.GetClassAliases(dataSetId);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IClassAliasDao
    {
        Task<List<ClassAlias>> GetClassAliases(int dataSetId);
    }
}
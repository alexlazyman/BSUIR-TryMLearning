using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.Services
{
    public interface IClassAliasService
    {
        Task<List<ClassAlias>> GetClassAliases(int dataSetId);
    }
}
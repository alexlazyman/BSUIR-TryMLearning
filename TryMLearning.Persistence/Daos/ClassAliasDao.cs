using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Interface.Daos;

namespace TryMLearning.Persistence.Daos
{
    public class ClassAliasDao : IClassAliasDao
    {
        private readonly TryMLearningDbContext _dbContext;

        public ClassAliasDao(TryMLearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClassAlias>> GetClassAliases(int dataSetId)
        {
            var classAliasDbEntities = await _dbContext.ClassAliases
                .Where(e => e.DataSetId == dataSetId)
                .ToListAsync();

            var classAliases = classAliasDbEntities.Select(Mapper.Map<ClassAlias>).ToList();

            return classAliases;
        }
    }
}
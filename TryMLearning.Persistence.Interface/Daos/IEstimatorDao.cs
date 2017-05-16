using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Persistence.Interface.Daos
{
    public interface IEstimatorDao
    {
        Task<List<Estimator>> GetAllEstimatorsAsync();
    }
}

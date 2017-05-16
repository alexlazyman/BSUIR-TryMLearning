using AutoMapper;
using TryMLearning.Persistence.Configuration;

namespace TryMLearning.AlgorithmWebJob
{
    public partial class Program
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RegisterDtoMaps();
            });
        }
    }
}
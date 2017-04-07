using AutoMapper;
using TryMLearning.Persistence.Configuration;

namespace TryMLearning.AlgorithmWebJob.WebJob_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
			Mapper.Initialize(cfg =>
			{
			    cfg.AddDtoMaps();
			});
        }
    }
}
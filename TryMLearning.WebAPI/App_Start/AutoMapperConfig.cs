using AutoMapper;
using TryMLearning.Configuration;

namespace TryMLearning.WebAPI
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
			Mapper.Initialize(cfg =>
			{
			    cfg.RegisterCommonMaps();
			});
        }
    }
}
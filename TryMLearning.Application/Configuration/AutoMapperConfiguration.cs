using AutoMapper;
using TryMLearning.Model;

namespace TryMLearning.Application.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterDtoMaps(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AlgorithmParameterForm, AlgorithmParameterValue>();

            cfg.CreateMap<AlgorithmForm, AlgorithmSession>()
                .ForMember(a => a.ParameterValues, opt => opt.MapFrom(s => s.Parameters));
        }
    }
}
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterDtoMaps(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Algorithm, AlgorithmDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameters, opt => opt.MapFrom(s => s.Parameters));
            cfg.CreateMap<AlgorithmDbEntity, Algorithm>()
                .ForMember(s => s.Parameters, opt => opt.MapFrom(sdb => sdb.AlgorithmParameters));

            cfg.CreateMap<AlgorithmParameter, AlgorithmParameterDbEntity>();
            cfg.CreateMap<AlgorithmParameterDbEntity, AlgorithmParameter>();

            cfg.CreateMap<AlgorithmParameterValue, AlgorithmParameterValueDbEntity>();
            cfg.CreateMap<AlgorithmParameterValueDbEntity, AlgorithmParameterValue>();

            cfg.CreateMap<AlgorithmSession, AlgorithmSessionDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameterValues, opt => opt.MapFrom(s => s.ParameterValues));
            cfg.CreateMap<AlgorithmSessionDbEntity, AlgorithmSession>()
                .ForMember(s => s.ParameterValues, opt => opt.MapFrom(sdb => sdb.AlgorithmParameterValues));
        }
    }
}
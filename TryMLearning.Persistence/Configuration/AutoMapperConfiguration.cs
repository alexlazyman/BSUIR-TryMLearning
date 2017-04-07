using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddDtoMaps(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Algorithm, AlgorithmDbEntity>();
            cfg.CreateMap<AlgorithmDbEntity, Algorithm>();

            cfg.CreateMap<AlgorithmParameter, AlgorithmParameterDbEntity>();
            cfg.CreateMap<AlgorithmParameterDbEntity, AlgorithmParameter>();

            cfg.CreateMap<AlgorithmParameterValue, AlgorithmParameterValueDbEntity>();
            cfg.CreateMap<AlgorithmParameterValueDbEntity, AlgorithmParameterValue>();

            cfg.CreateMap<AlgorithmSession, AlgorithmSessionDbEntity>();
            cfg.CreateMap<AlgorithmSessionDbEntity, AlgorithmSession>();
        }
    }
}
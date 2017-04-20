using System.Linq;
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
                .ForMember(sdb => sdb.AlgorithmParameters, opt => opt.Ignore());
            cfg.CreateMap<AlgorithmDbEntity, Algorithm>()
                .ForMember(s => s.Parameters, opt => opt.MapFrom(sdb => sdb.AlgorithmParameters));

            cfg.CreateMap<AlgorithmParameter, AlgorithmParameterDbEntity>();
            cfg.CreateMap<AlgorithmParameterDbEntity, AlgorithmParameter>();

            cfg.CreateMap<AlgorithmParameterValue, AlgorithmParameterValueDbEntity>();
            cfg.CreateMap<AlgorithmParameterValueDbEntity, AlgorithmParameterValue>();

            cfg.CreateMap<AlgorithmSession, AlgorithmSessionDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameterValues, opt => opt.Ignore());
            cfg.CreateMap<AlgorithmSessionDbEntity, AlgorithmSession>()
                .ForMember(s => s.ParameterValues, opt => opt.MapFrom(sdb => sdb.AlgorithmParameterValues));

            cfg.CreateMap<DataSet, DataSetDbEntity>();
            cfg.CreateMap<DataSetDbEntity, DataSet>();

            cfg.CreateMap<ClassificationDataSetSmaple, ClassificationDataSetSmapleDbEntity>()
                .ForMember(sdb => sdb.Count, opt => opt.ResolveUsing(s => s.Values?.Length ?? 0))
                .ForMember(sdb => sdb.DoubleTuple, opt => opt.ResolveUsing(s => s.Values != null ? new DoubleTupleDbEntity(s.Values) : null));
            cfg.CreateMap<ClassificationDataSetSmapleDbEntity, ClassificationDataSetSmaple>()
                .ForMember(s => s.Values, opt => opt.ResolveUsing(sdb => sdb.DoubleTuple.Take(sdb.Count).Cast<double>().ToArray()));
        }
    }
}
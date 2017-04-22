using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TryMLearning.Model;
using TryMLearning.Persistence.Models;
using TryMLearning.Persistence.Models.Map;

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
                .ForMember(sdb => sdb.DoubleTupleMaps, opt => opt.ResolveUsing(s =>
                {
                    if (s.Values == null)
                    {
                        return null;
                    }

                    var tupleCount = Math.Ceiling((double) s.Values.Length / DoubleTupleDbEntity.MaxCount);

                    var tupleMaps = new List<ClassificationDataSetSmapleDoubleTupleMap>();
                    for (int i = 0; i < tupleCount; i++)
                    {
                        var selectedValues = s.Values.Skip(i * DoubleTupleDbEntity.MaxCount);

                        tupleMaps.Add(new ClassificationDataSetSmapleDoubleTupleMap
                        {
                            DoubleTuple = new DoubleTupleDbEntity(selectedValues),
                            Order = i
                        });
                    }

                    return tupleMaps;
                }));
            cfg.CreateMap<ClassificationDataSetSmapleDbEntity, ClassificationDataSetSmaple>()
                .ForMember(s => s.Values, opt => opt.ResolveUsing(sdb =>
                {
                    if (sdb.DoubleTupleMaps == null)
                    {
                        return null;
                    }

                    var tuples = sdb.DoubleTupleMaps.OrderBy(m => m.Order).Select(m => m.DoubleTuple).ToArray();
                    var result = new List<double?>(tuples.Length * DoubleTupleDbEntity.MaxCount);

                    foreach (var tuple in tuples)
                    {
                        result.AddRange(tuple);
                    }

                    return result.Take(sdb.Count).Cast<double>().ToList();
                }));
        }
    }
}
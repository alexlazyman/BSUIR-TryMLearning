using System;
using System.Collections.Generic;
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

            cfg.CreateMap<AlgorithmEstimate, AlgorithmEstimateDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameterValues, opt => opt.Ignore());
            cfg.CreateMap<AlgorithmEstimateDbEntity, AlgorithmEstimate>()
                .ForMember(s => s.ParameterValues, opt => opt.MapFrom(sdb => sdb.AlgorithmParameterValues));

            cfg.CreateMap<DataSet, DataSetDbEntity>();
            cfg.CreateMap<DataSetDbEntity, DataSet>();

            cfg.CreateMap<ClassificationSample, ClassificationSampleDbEntity>()
                .ForMember(sdb => sdb.Count, opt => opt.ResolveUsing(s => s.Features?.Length ?? 0))
                .ForMember(sdb => sdb.FeatureTuples, opt => opt.ResolveUsing(ToFeatureTuples));
            cfg.CreateMap<ClassificationSampleDbEntity, ClassificationSample>()
                .ForMember(s => s.Features, opt => opt.ResolveUsing(ToFeatures));
        }

        private static List<DoubleTupleDbEntity> ToFeatureTuples(ClassificationSample classificationSample)
        {
            if (classificationSample.Features == null)
            {
                return null;
            }

            var tupleCount = Math.Ceiling((double)classificationSample.Features.Length / DoubleTupleDbEntity.MaxCount);
            IEnumerable<double> features = classificationSample.Features;

            var tuples = new List<DoubleTupleDbEntity>();
            for (int i = 0; i < tupleCount; i++)
            {
                tuples.Add(new DoubleTupleDbEntity(features, i));
                features = features.Skip(DoubleTupleDbEntity.MaxCount);
            }

            return tuples;
        }

        private static double[] ToFeatures(ClassificationSampleDbEntity classificationSampleDbEntity)
        {
            if (classificationSampleDbEntity.FeatureTuples == null)
            {
                return null;
            }

            var result = new double[classificationSampleDbEntity.Count];

            var i = 0;
            foreach (var doubleTuple in classificationSampleDbEntity.FeatureTuples.OrderBy(m => m.Order))
            {
                foreach (var doubleValue in doubleTuple)
                {
                    if (i >= classificationSampleDbEntity.Count)
                    {
                        break;
                    }

                    result[i] = doubleValue.Value;
                }
            }

            return result;
        }
    }
}
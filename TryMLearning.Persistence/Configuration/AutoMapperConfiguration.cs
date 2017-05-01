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
            cfg.CreateMap<Test, TestDbEntity>();
            cfg.CreateMap<TestDbEntity, Test>();

            cfg.CreateMap<Algorithm, AlgorithmDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameters, opt => opt.Ignore());
            cfg.CreateMap<AlgorithmDbEntity, Algorithm>()
                .ForMember(s => s.Parameters, opt => opt.MapFrom(sdb => sdb.AlgorithmParameters));

            cfg.CreateMap<AlgorithmParameter, AlgorithmParameterDbEntity>();
            cfg.CreateMap<AlgorithmParameterDbEntity, AlgorithmParameter>();

            cfg.CreateMap<AlgorithmParameterValue, AlgorithmParameterValueDbEntity>();
            cfg.CreateMap<AlgorithmParameterValueDbEntity, AlgorithmParameterValue>();

            cfg.CreateMap<AlgorithmEstimate, AlgorithmEstimateDbEntity>()
                .ForMember(sdb => sdb.AlgorithmParameterValues, opt => opt.Ignore())
                .ForMember(sdb => sdb.Algorithm, opt => opt.Ignore())
                .ForMember(sdb => sdb.AlgorithmId, opt => opt.ResolveUsing(s => s.Algorithm.AlgorithmId))
                .ForMember(sdb => sdb.DataSet, opt => opt.Ignore())
                .ForMember(sdb => sdb.DataSetId, opt => opt.ResolveUsing(s => s.DataSet.DataSetId))
                .ForMember(sdb => sdb.Test, opt => opt.Ignore())
                .ForMember(sdb => sdb.TestId, opt => opt.ResolveUsing(s => s.Test.TestId));
            cfg.CreateMap<AlgorithmEstimateDbEntity, AlgorithmEstimate>()
                .ForMember(s => s.ParameterValues, opt => opt.MapFrom(sdb => sdb.AlgorithmParameterValues))
                .ForMember(s => s.Algorithm, opt => opt.ResolveUsing(sdb => sdb.Algorithm ?? (object) new Algorithm(sdb.AlgorithmId)))
                .ForMember(s => s.DataSet, opt => opt.ResolveUsing(sdb => sdb.DataSet ?? (object) new DataSet(sdb.DataSetId)))
                .ForMember(s => s.Test, opt => opt.ResolveUsing(sdb => sdb.Test ?? (object) new Test(sdb.TestId)));

            cfg.CreateMap<DataSet, DataSetDbEntity>();
            cfg.CreateMap<DataSetDbEntity, DataSet>();

            cfg.CreateMap<ClassificationSample, ClassificationSampleDbEntity>()
                .ForMember(sdb => sdb.Count, opt => opt.ResolveUsing(s => s.Features?.Length ?? 0))
                .ForMember(sdb => sdb.FeatureTuples, opt => opt.ResolveUsing(s => ToDoubleTuples(s.Features)));
            cfg.CreateMap<ClassificationSampleDbEntity, ClassificationSample>()
                .ForMember(s => s.Features, opt => opt.ResolveUsing(s => FromDoubleTuples(s.Count, s.FeatureTuples)));

            cfg.CreateMap<ClassificationResult, ClassificationResultDbEntity>()
                .ForMember(sdb => sdb.Count, opt => opt.ResolveUsing(s => s.Answers?.Length ?? 0))
                .ForMember(sdb => sdb.AnswerTuples, opt => opt.ResolveUsing(s => ToBoolTuples(s.Answers)));
            cfg.CreateMap<ClassificationResultDbEntity, ClassificationResult>()
                .ForMember(s => s.Answers, opt => opt.ResolveUsing(s => FromBoolTuples(s.Count, s.AnswerTuples)));
        }

        private static List<DoubleTupleDbEntity> ToDoubleTuples(double[] values)
        {
            if (values == null)
            {
                return null;
            }

            var tupleCount = Math.Ceiling((double)values.Length / DoubleTupleDbEntity.Capacity);
            IEnumerable<double> valueEnumerable = values;

            var tuples = new List<DoubleTupleDbEntity>();
            for (int i = 0; i < tupleCount; i++)
            {
                tuples.Add(new DoubleTupleDbEntity(valueEnumerable, i));
                valueEnumerable = valueEnumerable.Skip(DoubleTupleDbEntity.Capacity);
            }

            return tuples;
        }

        private static List<BoolTupleDbEntity> ToBoolTuples(bool[] values)
        {
            if (values == null)
            {
                return null;
            }

            var tupleCount = Math.Ceiling((double)values.Length / BoolTupleDbEntity.Capacity);
            IEnumerable<bool> valueEnumerable = values;

            var tuples = new List<BoolTupleDbEntity>();
            for (int i = 0; i < tupleCount; i++)
            {
                tuples.Add(new BoolTupleDbEntity(valueEnumerable, i));
                valueEnumerable = valueEnumerable.Skip(BoolTupleDbEntity.Capacity);
            }

            return tuples;
        }

        private static double[] FromDoubleTuples(int count, IEnumerable<DoubleTupleDbEntity> tuples)
        {
            if (tuples == null)
            {
                return null;
            }

            var result = new double[count];

            var i = 0;
            foreach (var doubleTuple in tuples.OrderBy(m => m.Order))
            {
                foreach (var doubleValue in doubleTuple)
                {
                    if (i >= count)
                    {
                        break;
                    }

                    result[i++] = doubleValue.Value;
                }
            }

            return result;
        }

        private static bool[] FromBoolTuples(int count, IEnumerable<BoolTupleDbEntity> tuples)
        {
            if (tuples == null)
            {
                return null;
            }

            var result = new bool[count];

            var i = 0;
            foreach (var boolTuple in tuples.OrderBy(m => m.Order))
            {
                foreach (var boolValue in boolTuple)
                {
                    if (i >= count)
                    {
                        break;
                    }

                    result[i++] = boolValue.Value;
                }
            }

            return result;
        }
    }
}
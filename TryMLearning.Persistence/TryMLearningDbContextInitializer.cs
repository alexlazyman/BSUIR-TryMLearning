using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using TryMLearning.Data;
using TryMLearning.Model;
using TryMLearning.Model.Constants;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence
{
    public class TryMLearningDbContextInitializer : DropCreateDatabaseIfModelChanges<TryMLearningDbContext>
    {
        protected override void Seed(TryMLearningDbContext context)
        {
            context.Algorithms.AddRange(
                DefaultData.GetAlgorithms()
                    .Select(Mapper.Map<AlgorithmDbEntity>));

            context.SaveChanges();

            context.DataSets.AddRange(
                DefaultData.GetDataSets()
                    .Select(Mapper.Map<DataSetDbEntity>));

            context.SaveChanges();

            context.ClassificationDataSamples.AddRange(
                DefaultData.GetClassificationDataSetSamples()
                    .Select(Mapper.Map<ClassificationSampleDbEntity>));

            context.SaveChanges();
        }
}
}
using AutoMapper;
using TryMLearning.Persistence.Configuration;
using TryMLearning.Persistence.Data;
using TryMLearning.Persistence.Models;

namespace TryMLearning.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TryMLearningDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TryMLearningDbContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RegisterDtoMaps();
            });

            context.Users.AddRange(
                DefaultData.GetUsers()
                    .Select(Mapper.Map<UserDbEntity>));

            context.SaveChanges();

            context.Algorithms.AddRange(
                DefaultData.GetAlgorithms()
                    .Select(Mapper.Map<AlgorithmDbEntity>));

            context.SaveChanges();

            context.AlgorithmParameters.AddRange(
                DefaultData.GetAlgorithmParameters()
                    .Select(Mapper.Map<AlgorithmParameterDbEntity>));

            context.SaveChanges();

            context.Estimators.AddRange(
                DefaultData.GetEstimators()
                    .Select(Mapper.Map<EstimatorDbEntity>));

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

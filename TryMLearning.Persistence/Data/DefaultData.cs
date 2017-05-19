using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.AspNet.Identity;
using TryMLearning.Model;
using TryMLearning.Model.Constants;

namespace TryMLearning.Persistence.Data
{
    public static class DefaultData
    {
        public static IEnumerable<User> GetUsers()
        {
            var passwordHasher = new PasswordHasher();

            yield return new User
            {
                UserId = 1,
                UserName = "admin",
                PasswordHash = passwordHasher.HashPassword("12345678"),
                Email = "alexlazyman@gmail.com"
            };

            yield return new User
            {
                UserId = 2,
                UserName = "user1",
                PasswordHash = passwordHasher.HashPassword("12345678"),
                Email = "alexlazyman@gmail.com"
            };
        }

        public static IEnumerable<Algorithm> GetAlgorithms()
        {
            yield return new Algorithm
            {
                AlgorithmId = 1,
                Author = new User { UserId = 1 },
                Name = "Naive Bayes",
                Description = "There is no description",
                Alias = AlgorithmAliases.NaiveBayes,
                Type = AlgorithmType.Classifier,
                Parameters = new List<AlgorithmParameter>
                {
                }
            };
        }

        public static IEnumerable<AlgorithmParameter> GetAlgorithmParameters()
        {
            yield return new AlgorithmParameter
            {
                AlgorithmParameterId = 1,
                AlgorithmId = 1,
                Name = "Distribution",
                Description = "There is no description",
                Order = 0,
                ValueType = AlgorithmParameterType.Int
            };
        }

        public static IEnumerable<DataSet> GetDataSets()
        {
            yield return new DataSet
            {
                DataSetId = 1,
                Author = new User { UserId = 1 },
                Name = "Iris",
                Description = "There is no description",
                Type = DataSetType.Classification
            };

            yield return new DataSet
            {
                DataSetId = 2,
                Author = new User { UserId = 2 },
                Name = "Wine",
                Description = "There is no description",
                Type = DataSetType.Classification
            };
        }

        public static IEnumerable<ClassificationSample> GetClassificationDataSetSamples()
        {
            foreach (var tuple in ReadFromFile(@"Data/Iris.txt"))
            {
                yield return new ClassificationSample
                {
                    DataSetId = 1,
                    ClassId = tuple.Item1,
                    Features = tuple.Item2
                };
            }

            foreach (var tuple in ReadFromFile(@"Data/Wine.txt"))
            {
                yield return new ClassificationSample
                {
                    DataSetId = 2,
                    ClassId = tuple.Item1,
                    Features = tuple.Item2
                };
            }
        }

        private static IEnumerable<Tuple<int, double[]>> ReadFromFile(string path)
        {
            using (var fileStream = File.OpenRead(GetPath(path)))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var values = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);

                    var classId = (int) values.First();
                    var features = values.Skip(1).ToArray();

                    yield return Tuple.Create(classId, features);
                }
            }
        }

        private static string GetPath(string relativeFilePath)
        {
            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);

            return Path.Combine(directoryName, relativeFilePath);
        }
    }
}
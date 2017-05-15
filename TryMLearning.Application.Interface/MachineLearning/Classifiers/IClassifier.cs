﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TryMLearning.Model;

namespace TryMLearning.Application.Interface.MachineLearning.Classifiers
{
    public interface IClassifier
    {
        void Train(IEnumerable<ClassificationSample> samples);

        int Decide(ClassificationSample sample);
    }
}
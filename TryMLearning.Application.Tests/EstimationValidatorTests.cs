using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryMLearning.Application.Interface.Validation;
using TryMLearning.Application.Validation;
using TryMLearning.Model;

namespace TryMLearning.Application.Tests
{
    [TestClass]
    public class EstimationValidatorTests
    {
        private IValidator<Estimation> _estimationValidator;

        [TestInitialize]
        public void Init()
        {
            _estimationValidator = new EstimationValidator();
        }

        [TestMethod]
        public async Task ValidateEstimation_DataIsValid_ExpectedValidResult()
        {
            var estimation = ValidEstimation;

            var validationResult = await _estimationValidator.ValidateAsync(estimation);

            Assert.IsTrue(validationResult.IsValid);
        }

        [TestMethod]
        public async Task ValidateEstimation_EstimationIsNull_ExpectedInvalidResult()
        {
            Estimation estimation = null;

            var validationResult = await _estimationValidator.ValidateAsync(estimation);

            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public async Task ValidateEstimation_AlgorithmIsInvalid_ExpectedInvalidResult()
        {
            var estimation = ValidEstimation;
            estimation.Algorithm = null;

            var validationResult = await _estimationValidator.ValidateAsync(estimation);

            Assert.IsFalse(validationResult.IsValid);
        }

        [TestMethod]
        public async Task ValidateEstimation_DataSetIsInvalid_ExpectedInvalidResult()
        {
            var estimation = ValidEstimation;
            estimation.DataSet = null;

            var validationResult = await _estimationValidator.ValidateAsync(estimation);

            Assert.IsFalse(validationResult.IsValid);
        }

        private Estimation ValidEstimation => new Estimation()
        {
            Algorithm = new Algorithm(1),
            DataSet = new DataSet(1)
        };
    }
}

(function () {
    'use strict';

    var config = {
        algorithmType: {
            classifier: 0
        },
        dataSetType: {
            classification: 0
        },
        parameterType: {
            int: 0,
            double: 1,
            string: 2
        },
        estimationStatus: {
            waiting: 0,
            computing: 1,
            completed: 2
        },
        classifierEstimates: {
            generalizationAbility: 'GENERALIZATION-ABILITY',
            falsePositiveError: 'FALSE-POSITIVE-ERROR',
            falseNegativeError: 'FALSE-NEGATIVE-ERROR',
            rocCurve: 'ROC-CURVE'
        }
    };

    angular
        .module('app')
        .constant('config', config);
})();
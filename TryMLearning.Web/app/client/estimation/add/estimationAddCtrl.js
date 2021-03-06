﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationAddCtrl', estimationAddCtrl);

    estimationAddCtrl.$inject = [
        'spinnerSvc',
        'dataSetSvc',
        'algorithmSvc',
        'estimationSvc',
        '$q',
        '$scope',
        '$state',
        'config'
    ];

    function estimationAddCtrl(
        spinnerSvc,
        dataSetSvc,
        algorithmSvc,
        estimationSvc,
        $q,
        $scope,
        $state,
        config
    ) {
        var vm = this;

        vm.estimation = {
            parameterValues: []
        };

        vm.algorithms = undefined;
        vm.dataSets = undefined;

        vm.stringifyParamType = algorithmSvc.stringifyParamType;
        vm.getParamInputType = getParamInputType;
        vm.getParamInputType = getParamInputType;

        vm.estimateClick = estimateClick;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            spinnerSvc.registerLoader();

            var getAlgorithmsProm = algorithmSvc.getAllProm()
                .then(function(algorithms) {
                    vm.algorithms = algorithms;
                });

            var getDataSetsProm = dataSetSvc.getAllProm()
                .then(function (dataSets) {
                    vm.dataSets = dataSets;
                });

            $q.all([
                getAlgorithmsProm,
                getDataSetsProm
            ]).finally(function () {
                spinnerSvc.unregisterLoader();
            });
        }

        function estimateClick() {
            if ($scope.esimationForm.$invalid) {
                $scope.esimationForm.$setSubmitted();
                return;
            }

            spinnerSvc.registerLoader();
            estimationSvc.estimateProm(vm.estimation)
                .then(function (estimation) {
                    $state.go('client.estimation.resultComposer', { id: estimation.estimationId });
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }

        function getParamInputType(type) {
            switch (type) {
                case config.parameterType.int:
                case config.parameterType.double:
                    return 'number';
                case config.parameterType.string:
                    return 'string';
                default:
                    throw Error('Unknown type');
            }
        }
    }
})();

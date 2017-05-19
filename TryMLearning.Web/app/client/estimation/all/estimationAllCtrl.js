(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationAllCtrl', estimationAllCtrl);

    estimationAllCtrl.$inject = [
        'spinnerSvc',
        'estimationSvc',
        'algorithmSvc',
        '$state'
    ];

    function estimationAllCtrl(
        spinnerSvc,
        estimationSvc,
        algorithmSvc,
        $state
    ) {
        var vm = this;

        var selectedEstimations = [];

        vm.estimations = undefined;

        vm.stringifyStatus = estimationSvc.stringifyStatus;
        vm.selectedEstimationFilter = selectedEstimationFilter;
        vm.selectEstimationClick = selectEstimationClick;
        vm.estimationDeleteClick = estimationDeleteClick;

        vm.getParamValue = getParamValue;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            spinnerSvc.registerLoader();
            estimationSvc.getAllProm()
                .then(function (estimations) {
                    vm.estimations = estimations;
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }

        function getParamValue(param, paramValues) {
            var paramValue = _.find(paramValues, { algorithmParameterId: param.algorithmParameterId });

            return paramValue[algorithmSvc.stringifyParamType(param.valueType) + 'Value'];
        }

        function selectedEstimationFilter(estimation) {
            var etalonEstimation = _.first(selectedEstimations);
            if (!etalonEstimation) {
                return true;
            }

            return estimation.algorithm.algorithmId === etalonEstimation.algorithm.algorithmId
                && estimation.dataSet.dataSetId === etalonEstimation.dataSet.dataSetId;
        }

        function selectEstimationClick(estimation) {
            if (estimation.$selected) {
                selectedEstimations.push(estimation);
            } else {
                var i = _.findIndex(selectedEstimations, estimation);

                selectedEstimations.splice(i, 1);
            }

            var ids = _.map(selectedEstimations, function (e) { return e.algorithmEstimationId; });

            $state.params.id = ids;
        }

        function estimationDeleteClick(estimation) {
            spinnerSvc.registerLoader();
            estimationSvc.deleteProm(estimation.algorithmEstimationId)
                .then(function () {
                    var i = _.findIndex(vm.estimations, estimation);
                    vm.estimations.splice(i, 1);
                }, function() {
                    alert('Something wen wrong.');
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
            
        }
    }
})();

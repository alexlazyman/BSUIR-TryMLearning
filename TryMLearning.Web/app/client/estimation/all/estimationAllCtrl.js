(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationAllCtrl', estimationAllCtrl);

    estimationAllCtrl.$inject = [
        'spinnerSvc',
        'estimationSvc',
        'algorithmSvc'
    ];

    function estimationAllCtrl(
        spinnerSvc,
        estimationSvc,
        algorithmSvc
    ) {
        var vm = this;

        vm.estimations = undefined;

        vm.stringifyStatus = estimationSvc.stringifyStatus;

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
    }
})();

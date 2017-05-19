(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationResultCtrl', estimationResultCtrl);

    estimationResultCtrl.$inject = [
        'spinnerSvc',
        'estimationSvc',
        '$state'
    ];

    function estimationResultCtrl(
        spinnerSvc,
        estimationSvc,
        $state
    ) {
        var vm = this;

        vm.estimateConfigs = undefined;
        vm.estimateResults = undefined;

        activate();

        function activate() {
            loadData();
        }
        
        function loadData() {
            var estimateConfigs = $state.params.e;
            if (!_.isArray(estimateConfigs)) {
                estimateConfigs = [estimateConfigs];
            }

            spinnerSvc.registerLoader();
            estimationSvc.getResultProm($state.params.id, estimateConfigs)
                .then(function (estimateResults) {
                    vm.estimateConfigs = estimateConfigs;
                    vm.estimateResults = [estimateResults];
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

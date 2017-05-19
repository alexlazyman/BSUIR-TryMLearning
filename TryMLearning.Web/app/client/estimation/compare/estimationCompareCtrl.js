(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationCompareCtrl', estimationCompareCtrl);

    estimationCompareCtrl.$inject = [
        'spinnerSvc',
        'estimationSvc',
        '$state',
        '$q'
    ];

    function estimationCompareCtrl(
        spinnerSvc,
        estimationSvc,
        $state,
        $q
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

            var proms = [];

            spinnerSvc.registerLoader();

            _.each($state.params.id, function(id) {
                proms.push(estimationSvc.getResultProm(id, estimateConfigs));
            });

            $q.all(proms)
                .then(function (estimateResultsCollection) {
                    vm.estimateConfigs = estimateConfigs;
                    vm.estimateResults = [];

                    for (var i = 0; i < vm.estimateConfigs.length; i++) {
                        var estimateResults = _.map(estimateResultsCollection, function (estimateResults) {
                            return estimateResults[i];
                        });

                        vm.estimateResults.push(estimateResults);
                    }
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

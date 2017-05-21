(function () {
    'use strict';

    angular
        .module('app')
        .filter('joinBy', function () {
            return function (input, delimiter) {
                return (input || []).join(delimiter || ',');
            };
        })
        .controller('dataSetDetailsCtrl', dataSetDetailsCtrl);

    dataSetDetailsCtrl.$inject = [
        'spinnerSvc',
        'dataSetSvc',
        'sampleSvc',
        '$state',
        '$q'
    ];

    function dataSetDetailsCtrl(
        spinnerSvc,
        dataSetSvc,
        sampleSvc,
        $state,
        $q
    ) {
        var vm = this;

        vm.stringifyType = dataSetSvc.stringifyType;

        vm.dataSet = undefined;
        vm.samples = undefined;
        vm.classAliases = undefined;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var dataSetId = $state.params.id;

            spinnerSvc.registerLoader();
            dataSetSvc.getProm(dataSetId)
                .then(function (dataSet) {
                    vm.dataSet = dataSet;

                    return $q.all(sampleSvc.getSamplesProm(dataSet.dataSetId, dataSet.type));
                })
                .then(function (results) {
                    vm.samples = results[0];
                    vm.classAliases = results[1];
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

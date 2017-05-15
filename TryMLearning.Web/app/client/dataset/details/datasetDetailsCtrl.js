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
        '$state'
    ];

    function dataSetDetailsCtrl(
        spinnerSvc,
        dataSetSvc,
        sampleSvc,
        $state
    ) {
        var vm = this;

        vm.stringifyType = dataSetSvc.stringifyType;

        vm.dataSet = undefined;
        vm.samples = undefined;

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

                    return sampleSvc.getSamplesProm(dataSet.dataSetId, dataSet.type);
                })
                .then(function (samples) {
                    vm.samples = samples;
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

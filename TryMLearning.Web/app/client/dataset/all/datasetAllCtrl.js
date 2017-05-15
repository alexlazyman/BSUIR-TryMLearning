(function () {
    'use strict';

    angular
        .module('app')
        .controller('dataSetAllCtrl', dataSetAllCtrl);

    dataSetAllCtrl.$inject = [
        'spinnerSvc',
        'dataSetSvc'
    ];

    function dataSetAllCtrl(
        spinnerSvc,
        dataSetSvc
    ) {
        var vm = this;

        vm.stringifyType = dataSetSvc.stringifyType;

        vm.dataSets = undefined;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            spinnerSvc.registerLoader();
            dataSetSvc.getAllProm()
                .then(function (dataSets) {
                    vm.dataSets = dataSets;
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

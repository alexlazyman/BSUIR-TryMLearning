(function () {
    'use strict';

    angular
        .module('app')
        .controller('algorithmAllCtrl', algorithmAllCtrl);

    algorithmAllCtrl.$inject = [
        'algorithmSvc',
        'spinnerSvc'
    ];

    function algorithmAllCtrl(
        algorithmSvc,
        spinnerSvc
    ) {
        var vm = this;

        vm.algorithms = undefined;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            spinnerSvc.registerLoader();
            algorithmSvc.getAllProm()
                .then(function (algorithms) {
                    vm.algorithms = algorithms;
                })
                .finally(function() {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

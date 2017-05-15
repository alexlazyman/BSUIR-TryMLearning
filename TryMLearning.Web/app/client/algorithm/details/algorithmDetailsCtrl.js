(function () {
    'use strict';

    angular
        .module('app')
        .controller('algorithmDetailsCtrl', algorithmDetailsCtrl);

    algorithmDetailsCtrl.$inject = [
        '$state',
        'algorithmSvc',
        'spinnerSvc'
    ];

    function algorithmDetailsCtrl(
        $state,
        algorithmSvc,
        spinnerSvc
    ) {
        var vm = this;

        vm.algorithm = undefined;

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            var algorithmId = $state.params.id;

            spinnerSvc.registerLoader();
            algorithmSvc.getProm(algorithmId)
                .then(function (algorithm) {
                    vm.algorithm = algorithm;
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

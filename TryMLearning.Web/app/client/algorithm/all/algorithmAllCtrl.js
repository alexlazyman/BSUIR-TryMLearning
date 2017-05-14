(function () {
    'use strict';

    angular
        .module('app')
        .controller('algorithmAllCtrl', algorithmAllCtrl);

    algorithmAllCtrl.$inject = [
        'algorithmSvc'
    ];

    function algorithmAllCtrl(
        algorithmSvc
    ) {
        var vm = this;

        vm.algorithms = [];

        activate();

        function activate() {
            loadData();
        }

        function loadData() {
            algorithmSvc.getAll()
                .then(function (algorithms) {
                    vm.algorithms = algorithms;
                });
        }
    }
})();

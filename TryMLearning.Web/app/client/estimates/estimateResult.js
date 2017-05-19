(function () {
    'use strict';

    angular
        .module('app')
        .directive('estimateResult', estimateResult);

    estimateResult.$inject = [
    ];

    function estimateResult(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/estimateResult.html',
            scope: {},
            bindToController: {
                alias: '=',
                config: '=',
                result: '=',
            },
            controller: estimateResultCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    estimateResultCtrl.$inject = [
        'config'
    ];

    function estimateResultCtrl(
        config
    ) {
        var vm = this;

        vm.classifierEstimateAliases = config.classifierEstimates;

        activate();

        function activate() {
        }
    }

})();
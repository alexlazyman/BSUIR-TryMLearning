(function () {
    'use strict';

    angular
        .module('app')
        .directive('estimateComposer', estimateComposer);

    estimateComposer.$inject = [
    ];

    function estimateComposer(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/estimateComposer.html',
            scope: {},
            require: {
                 form: '^^form'
            },
            bindToController: {
                estimate: '='
            },
            controller: estimateComposerCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    estimateComposerCtrl.$inject = [
        'config'
    ];

    function estimateComposerCtrl(
        config
    ) {
        var vm = this;

        vm.classifierEstimateAliases = config.classifierEstimates;

        activate();

        function activate() {
        }
    }

})();
(function () {
    'use strict';

    angular
        .module('app')
        .directive('classDefaultEstimateComposer', classDefaultEstimateComposer);

    classDefaultEstimateComposer.$inject = [
    ];

    function classDefaultEstimateComposer(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/classDefaultEstimate/classDefaultEstimateComposer.html',
            scope: {},
            bindToController: {
                form: '=',
                estimate: '='
            },
            controller: classDefaultEstimateComposerCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    classDefaultEstimateComposerCtrl.$inject = [
        'config'
    ];

    function classDefaultEstimateComposerCtrl(
        config
    ) {
        var vm = this;

        vm.classifierEstimateAliases = config.classifierEstimates;

        activate();

        function activate() {
        }
    }

})();
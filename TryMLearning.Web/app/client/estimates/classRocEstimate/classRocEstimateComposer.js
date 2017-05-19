(function () {
    'use strict';

    angular
        .module('app')
        .directive('classRocEstimateComposer', classRocEstimateComposer);

    classRocEstimateComposer.$inject = [
    ];

    function classRocEstimateComposer(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/classRocEstimate/classRocEstimateComposer.html',
            scope: {},
            bindToController: {
                form: '=',
                estimate: '='
            },
            controller: classRocEstimateComposerCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    classRocEstimateComposerCtrl.$inject = [
        'config'
    ];

    function classRocEstimateComposerCtrl(
        config
    ) {
        var vm = this;

        vm.classifierEstimateAliases = config.classifierEstimates;

        activate();

        function activate() {
        }
    }

})();
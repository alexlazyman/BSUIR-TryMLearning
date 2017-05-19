(function () {
    'use strict';

    angular
        .module('app')
        .directive('classDefaultEstimate', classDefaultEstimate);

    classDefaultEstimate.$inject = [
    ];

    function classDefaultEstimate(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/classDefaultEstimate/classDefaultEstimate.html',
            scope: {},
            bindToController: {
                result: '=',
                config: '='
            },
            controller: classDefaultEstimateCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    classDefaultEstimateCtrl.$inject = [
    ];

    function classDefaultEstimateCtrl(
    ) {
        var vm = this;

        activate();

        function activate() {
        }
    }

})();
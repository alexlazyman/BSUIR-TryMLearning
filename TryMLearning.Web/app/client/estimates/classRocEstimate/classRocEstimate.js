(function () {
    'use strict';

    angular
        .module('app')
        .directive('classRocEstimate', classRocEstimate);

    classRocEstimate.$inject = [
    ];

    function classRocEstimate(
    ) {
        var directive = {
            templateUrl: '/app/client/estimates/classRocEstimate/classRocEstimate.html',
            scope: {},
            bindToController: {
                result: '=',
                config: '='
            },
            controller: classRocEstimateCtrl,
            controllerAs: 'vm',
            restrict: 'E'
        };

        return directive;
    }

    classRocEstimateCtrl.$inject = [
        '$scope'
    ];

    function classRocEstimateCtrl(
        $scope
    ) {
        var vm = this;

        activate();

        function activate() {
            registerWatchers();
        }

        function registerWatchers() {
            $scope.$watch('vm.result', function (){
                if (!vm.result) {
                    return;
                }

                vm.result.$chart = getChartConfig(vm.result);
            });
        }

        function getChartConfig(results) {
            return {
                series: ['Series'],
                data: _.map(results, function(result) {
                    return _.map(result.properties.curve, function(d) { return { x: d.fpr, y: d.sens } });
                }),
                options: {
                    scales: {
                        xAxes: [{
                            scaleLabel: {
                                display: true,
                                labelString: 'False Positive Rate'
                            },
                            type: 'linear',
                            position: 'bottom'
                        }],
                        yAxes: [{
                            scaleLabel: {
                                display: true,
                                labelString: 'Sensitivity'
                            }
                        }]
                    },
                    tooltips: {
                        callbacks: {
                            title: function (e) {
                                return e[0].xLabel.toFixed(4) + ' - ' + e[0].yLabel.toFixed(4);
                            },
                            label: function (e) {
                                return false;
                            }
                        }
                    }
                }
            };
        }
    }

})();
(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationResultCtrl', estimationResultCtrl);

    estimationResultCtrl.$inject = [
        'spinnerSvc',
        'estimationSvc',
        '$state',
        'config'
    ];

    function estimationResultCtrl(
        spinnerSvc,
        estimationSvc,
        $state,
        config
    ) {
        var vm = this;

        vm.results = undefined;
        vm.estimateAliases = config.classifierEstimates;

        activate();

        function activate() {
            loadData();
        }
        
        function loadData() {
            var estimates = $state.params.e;
            if (!_.isArray(estimates)) {
                estimates = [estimates];
            }

            spinnerSvc.registerLoader();
            estimationSvc.getResultProm($state.params.id, estimates)
                .then(function (results) {
                    vm.results = results;

                    for (var i = 0; i < vm.results.length; i++) {
                        vm.results[i].$src = estimates[i];

                        if (estimates[i].alias === config.classifierEstimates.rocCurves) {
                            _.reverse(vm.results[i].value);
                            vm.results[i].$chart = getChartConfig(vm.results[i].value);
                        }
                    }
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }

        function getChartConfig(data) {
            return {
                series: ['Series'],
                data: [
                    _.map(data, function (d) { return { x: d.v1, y: d.v2 } })
                ],
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

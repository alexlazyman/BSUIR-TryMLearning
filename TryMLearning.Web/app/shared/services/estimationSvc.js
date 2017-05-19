(function () {
    'use strict';

    angular
        .module('app')
        .factory('estimationSvc', estimationSvc);

    estimationSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc',
        'config'
    ];

    function estimationSvc(
        $http,
        urlBuilder,
        promiseSvc,
        config
    ) {
        var service = {
            deleteProm: deleteProm,
            getProm: getProm,
            getAllProm: getAllProm,
            estimateProm: estimateProm,
            getResultProm: getResultProm,
            stringifyStatus: stringifyStatus
        };

        return service;

        function deleteProm(estimationId) {
            var url = urlBuilder.build('api/estimation/' + estimationId);

            return $http.delete(url)
                .then(promiseSvc.requestComplete);
        }

        function getProm(estimationId) {
            var url = urlBuilder.build('api/estimation/' + estimationId);

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function getAllProm() {
            var url = urlBuilder.build('api/estimation');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function estimateProm(estimation) {
            switch (estimation.algorithm.type) {
                case config.algorithmType.classifier:
                    return estimateClassifierProm(estimation);
            default:
                return null;
            }
        }

        function estimateClassifierProm(estimation) {
            var url = urlBuilder.build('api/estimation/classifier');

            return $http.post(url, estimation)
                .then(promiseSvc.requestComplete);
        }

        function getResultProm(estimationId, estimates) {
            estimates = angular.copy(estimates); 

            _.each(estimates, function(e) {
                e.config = JSON.stringify(e.config);
            });

            var params = {
                id: estimationId,
                e: JSON.stringify(estimates)
            }

            var url = urlBuilder.build('api/estimation/classifier/result');

            return $http.get(url, { params: params })
                .then(promiseSvc.requestComplete);
        }

        function stringifyStatus(status) {
            switch (status) {
                case config.estimationStatus.waiting:
                    return 'waiting';
                case config.estimationStatus.computing:
                    return 'computing';
                case config.estimationStatus.completed:
                    return 'completed';
                default:
                    return 'unknown';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('estimatorSvc', estimatorSvc);

    estimatorSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc'
    ];

    function estimatorSvc(
        $http,
        urlBuilder,
        promiseSvc
    ) {
        var service = {
            getAllProm: getAllProm
        };

        return service;

        function getAllProm() {
            var url = urlBuilder.build('api/estimator');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }
    }
})();
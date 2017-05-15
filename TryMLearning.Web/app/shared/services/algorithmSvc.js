(function () {
    'use strict';

    angular
        .module('app')
        .factory('algorithmSvc', algorithmSvc);

    algorithmSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc'
    ];

    function algorithmSvc(
        $http,
        urlBuilder,
        promiseSvc
    ) {
        var service = {
            getProm: getProm,
            getAllProm: getAllProm
        };

        return service;

        function getProm(algorithmId) {
            var url = urlBuilder.build('api/algorithm/' + algorithmId);

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function getAllProm() {
            var url = urlBuilder.build('api/algorithm');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }
    }
})();
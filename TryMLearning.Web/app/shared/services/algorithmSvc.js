(function () {
    'use strict';

    angular
        .module('app')
        .factory('algorithmSvc', algorithmSvc);

    algorithmSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc',
        'config'
    ];

    function algorithmSvc(
        $http,
        urlBuilder,
        promiseSvc,
        config
    ) {
        var service = {
            getProm: getProm,
            getAllProm: getAllProm,
            stringifyParamType: stringifyParamType
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

        function stringifyParamType(type) {
            switch(type) {
                case config.parameterType.int:
                    return 'int';
                case config.parameterType.double:
                    return 'double';
                case config.parameterType.string:
                    return 'string';
                default:
                    return 'unknown';
            }
        }
    }
})();
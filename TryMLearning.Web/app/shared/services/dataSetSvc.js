(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataSetSvc', dataSetSvc);

    dataSetSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc'
    ];

    function dataSetSvc(
        $http,
        urlBuilder,
        promiseSvc
    ) {
        var service = {
            getProm: getProm,
            getAllProm: getAllProm,
            stringifyType: stringifyType
        };

        return service;

        function getProm(dataSetId) {
            var url = urlBuilder.build('api/dataSet/' + dataSetId);

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function getAllProm() {
            var url = urlBuilder.build('api/dataSet');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function stringifyType(type) {
            switch (type) {
                case 0:
                    return 'classification';
                default:
                    return 'unknown';
            }
        }
    }
})();
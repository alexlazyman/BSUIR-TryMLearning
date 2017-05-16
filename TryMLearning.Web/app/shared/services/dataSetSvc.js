(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataSetSvc', dataSetSvc);

    dataSetSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc',
        'config'
    ];

    function dataSetSvc(
        $http,
        urlBuilder,
        promiseSvc,
        config
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
                case config.dataSetType.classification:
                    return 'classification';
                default:
                    return 'unknown';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('sampleSvc', sampleSvc);

    sampleSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc',
        'config'
    ];

    function sampleSvc(
        $http,
        urlBuilder,
        promiseSvc,
        config
    ) {
        var service = {
            getSamplesProm: getSamplesProm,
            getClassAliasesProm: getClassAliasesProm
        };

        return service;

        function getSamplesProm(dataSetId, dataSetType) {
            switch (dataSetType) {
                case config.dataSetType.classification:
                    return [
                        getClassificationSamplesProm(dataSetId),
                        getClassAliasesProm(dataSetId)
                    ];
                default:
                    return null;
            }
        }

        function getClassAliasesProm(dataSetId) {
            var url = urlBuilder.build('api/dataset/' + dataSetId + '/classes');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }

        function getClassificationSamplesProm(dataSetId) {
            var url = urlBuilder.build('api/dataset/' + dataSetId + '/sample/classification');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }
    }
})();
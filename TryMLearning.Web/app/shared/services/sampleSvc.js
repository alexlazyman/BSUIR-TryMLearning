(function () {
    'use strict';

    angular
        .module('app')
        .factory('sampleSvc', sampleSvc);

    sampleSvc.$inject = [
        '$http',
        'urlBuilder',
        'promiseSvc'
    ];

    function sampleSvc(
        $http,
        urlBuilder,
        promiseSvc
    ) {
        var service = {
            getSamplesProm: getSamplesProm
        };

        return service;

        function getSamplesProm(dataSetId, dataSetType) {
            switch (dataSetType) {
                case 0:
                    return getClassificationSamplesProm(dataSetId);
                default:
                    return null;
            }
        }

        function getClassificationSamplesProm(dataSetId) {
            var url = urlBuilder.build('api/dataset/' + dataSetId + '/sample/classification');

            return $http.get(url)
                .then(promiseSvc.requestComplete);
        }
    }
})();
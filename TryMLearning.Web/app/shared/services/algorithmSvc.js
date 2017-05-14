(function () {
    'use strict';

    angular
        .module('app')
        .factory('algorithmSvc', algorithmSvc);

    algorithmSvc.$inject = [
        '$http',
        'urlBuilder'
    ];

    function algorithmSvc(
        $http,
        urlBuilder
    ) {
        var service = {
            getAll: getAll
        };

        return service;

        function getAll() {
            var url = urlBuilder.build('api/algorithm');

            return $http.get(url).then(function(response) {
                return response.data;
            });
        }
    }
})();
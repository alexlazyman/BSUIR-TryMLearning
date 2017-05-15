(function () {
    'use strict';

    angular
        .module('app')
        .factory('promiseSvc', promiseSvc);

    promiseSvc.$inject = ['$q'];

    function promiseSvc($q) {
        var service = {
            requestComplete: requestComplete,
            requestFailed: requestFailed
        };

        return service;

        function requestComplete(response) {
            return response.data;
        }

        function requestFailed(error) {
            return $q.reject(error);
        }
    }
})();

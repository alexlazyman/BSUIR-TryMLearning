(function () {
    'use strict';

    angular
        .module('app')
        .factory('spinnerSvc', spinnerSvc);

    spinnerSvc.$inject = [
        '$q'
    ];

    function spinnerSvc(
        $q
    ) {
        var activatorsCount = 0;
        var defered = null;

        var service = {
            isActive: isActive,
            registerLoader: registerLoader,
            unregisterLoader: unregisterLoader
        };

        return service;

        function registerLoader() {
            if (!isActive()) {
                defered = $q.defer();
            }

            activatorsCount++;

            return defered.promise;
        }

        function unregisterLoader() {
            activatorsCount--;

            if (!isActive()) {
                defered.resolve();
                defered = null;
            }
        }

        function isActive() {
            return activatorsCount !== 0;
        }
    }
})();
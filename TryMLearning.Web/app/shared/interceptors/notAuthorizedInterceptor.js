(function () {
    'use strict';

    angular
        .module('app')
        .factory('notAuthorizedInterceptor', notAuthorizedInterceptor);

    notAuthorizedInterceptor.$inject = [
        '$q',
        '$rootScope'
    ];

    function notAuthorizedInterceptor(
        $q,
        $rootScope
    ) {
        var requestInterceptor = {
            responseError: function (rejection) {
                if (!rejection) {
                    return $q.reject(rejection);
                }

                if (rejection.status === 401 && (!rejection.data || rejection.data.error !== "invalid_token")) {
                    $rootScope.$emit("auth:error", rejection);
                }

                return $q.reject(rejection);
            }
        };

        return requestInterceptor;
    }
})();
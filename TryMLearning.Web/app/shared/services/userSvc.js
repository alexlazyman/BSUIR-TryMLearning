(function () {
    'use strict';

    angular
        .module('app')
        .factory('userSvc', userSvc);

    userSvc.$inject = [
        '$http',
        'urlBuilder'
    ];

    function userSvc(
        $http,
        urlBuilder
    ) {
        var service = {
            getData: getData
        };

        return service;

        function signIn() {

        }
    }


})();
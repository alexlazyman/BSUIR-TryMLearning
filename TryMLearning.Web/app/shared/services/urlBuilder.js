(function () {
    'use strict';

    angular
        .module('app')
        .factory('urlBuilder', urlBuilder);

    urlBuilder.$inject = [
        '$window'
    ];

    function urlBuilder(
        $window
    ) {
        var service = {
            getBaseUrl,
            build: build
        };

        return service;

        function getBaseUrl() {
            return $window.tryMLearningWebApiSrvUri;
        }

        function build(url) {
            return getBaseUrl() + url;
        }
    }
})();
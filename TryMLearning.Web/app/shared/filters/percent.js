(function () {
    'use strict';

    angular
        .module('app')
        .filter('percent', percentFilter);

    function percentFilter() {
        return function (num) {
            return (num * 100.0).toFixed(2) + '%';
        };
    }
})();
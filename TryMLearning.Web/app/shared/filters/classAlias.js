(function () {
    'use strict';

    angular
        .module('app')
        .filter('classAlias', classAliasFilter);

    function classAliasFilter() {
        return function (classId, classAliases) {
            if (!classAliases) {
                return classId;
            }

            var classAlias = _.find(classAliases, { classId: classId });
            if (!classAlias) {
                return classId;
            }

            return classAlias.alias;
        };
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .controller('estimationCtrl', estimationCtrl);

    estimationCtrl.$inject = [
        '$state'
    ];

    function estimationCtrl(
        $state
    ) {
        var vm = this;

        vm.isState = $state.is;
        vm.includesState = $state.includes;

        vm.isCmpLinkEnabled = isCmpLinkEnabled;
        vm.cmpLinkClick = cmpLinkClick;

        activate();

        function activate() {
        }

        function isCmpLinkEnabled() {
            return $state.is('client.estimation.all') && isValidCmp();
        }

        function cmpLinkClick() {
            $state.go('client.estimation.resultComposer', { id: $state.params.id, e: null });
        }

        function isValidCmp() {
            return _.isArray($state.params.id)
                && $state.params.id.length > 1;
        }
    }
})();

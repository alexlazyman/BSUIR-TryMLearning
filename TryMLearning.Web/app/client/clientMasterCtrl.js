(function () {
    'use strict';

    angular
        .module('app')
        .controller('clientMasterCtrl', clientMasterCtrl);

    clientMasterCtrl.$inject = [
        'OAuth',
        '$state',
        'spinnerSvc'
    ];

    function clientMasterCtrl(
        OAuth,
        $state,
        spinnerSvc
    ) {
        var vm = this;

        vm.isAuthenticated = OAuth.isAuthenticated;
        vm.isState = $state.is;
        vm.includesState = $state.includes;
        vm.isSpinnerActive = spinnerSvc.isActive;

        vm.signOutClick = signOutClick;

        activate();

        function activate() {
        }

        function signOutClick() {
            OAuth.revokeToken()
                .then(function() {
                    $state.go('client.home');
                });
        }
    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('signinCtrl', signinCtrl);

    signinCtrl.$inject = [
        'OAuth',
        '$state',
        'spinnerSvc'
    ];

    function signinCtrl(
        OAuth,
        $state,
        spinnerSvc
    ) {
        var vm = this;

        vm.loginClick = loginClick;

        activate();

        function activate() {
        }

        function loginClick() {
            var data = {
                username: vm.userName,
                password: vm.password
            }

            spinnerSvc.registerLoader();
            OAuth.getAccessToken(data)
                .then(function () {
                    $state.go('client.home');
                })
                .finally(function () {
                    spinnerSvc.unregisterLoader();
                });
        }
    }
})();

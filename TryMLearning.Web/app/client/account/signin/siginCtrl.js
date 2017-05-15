(function () {
    'use strict';

    angular
        .module('app')
        .controller('siginCtrl', siginCtrl);

    siginCtrl.$inject = [
        'OAuth',
        '$state'
    ];

    function siginCtrl(
        OAuth,
        $state
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

            OAuth.getAccessToken(data)
                .then(function () {
                    $state.go('client.home');
                });
        }
    }
})();

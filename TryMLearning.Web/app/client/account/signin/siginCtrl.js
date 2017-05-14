(function () {
    'use strict';

    angular
        .module('app')
        .controller('siginCtrl', siginCtrl);

    siginCtrl.$inject = [
        'OAuth',
        '$cookies'
    ];

    function siginCtrl(
        OAuth,
        $cookies
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

            OAuth.getAccessToken(data);
        }
    }
})();

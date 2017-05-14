(function () {
    'use strict';

    angular
        .module('app')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = [
        '$http'
    ];

    function homeCtrl(
        $http
    ) {
        var vm = this;

        vm.userRegisterForm = {};
        vm.loginForm = {};

        vm.registerClick = registerClick;
        vm.loginClick = loginClick;

        activate();

        function activate() {
        }

        function registerClick() {
            $http.post('http://localhost:57929/api/Account/Register', vm.userRegisterForm)
                .then(function(response) {
                    debugger;
                });
        }

        function loginClick() {
            var loginData = 'userName=' + vm.loginForm.userName + '&password=' + vm.loginForm.password + '&grant_type=password';

            $http.post('http://localhost:57929/Token', loginData, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function (response) {
                    debugger;
                });
        }
    }
})();

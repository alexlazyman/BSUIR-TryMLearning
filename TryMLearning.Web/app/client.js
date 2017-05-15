(function () {
    'use strict';

    angular
        .module('app', [
            'ng',
            'angularSpinner',
            'ui.router',
            'angular-oauth2'
        ])
        .config(config)
        .run(run);

    config.$inject = [
        '$stateProvider',
        '$locationProvider',
        '$urlRouterProvider',
        'OAuthProvider',
        '$httpProvider',
        'OAuthTokenProvider'
    ];

    function config(
        $stateProvider,
        $locationProvider,
        $urlRouterProvider,
        OAuthProvider,
        $httpProvider,
        OAuthTokenProvider
    ) {
        $stateProvider
            .state('client',
            {
                abstract: true,
                url: '/client',
                templateUrl: '/app/client/clientMaster.html',
                controller: 'clientMasterCtrl',
                controllerAs: 'vm'
            })
            .state('client.signin',
            {
                url: '/signin',
                templateUrl: '/app/client/account/signin/signin.html',
                controller: 'siginCtrl',
                controllerAs: 'vm'
            })
            .state('client.signup',
            {
                url: '/signup',
                templateUrl: '/app/client/account/signup/signup.html',
                controller: 'sigupCtrl',
                controllerAs: 'vm'
            })
            .state('client.home',
            {
                url: '/home',
                templateUrl: '/app/client/home/home.html',
                controller: 'homeCtrl',
                controllerAs: 'vm'
            })
            .state('client.algorithm',
            {
                url: '/algorithm?id',
                templateUrl: '/app/client/algorithm/details/algorithmDetails.html',
                controller: 'algorithmDetailsCtrl',
                controllerAs: 'vm'
            })
            .state('client.algorithmAll',
            {
                url: '/algorithms',
                templateUrl: '/app/client/algorithm/all/algorithmAll.html',
                controller: 'algorithmAllCtrl',
                controllerAs: 'vm'
            })
            .state('client.dataSet',
            {
                url: '/dataset?id',
                templateUrl: '/app/client/dataSet/details/dataSetDetails.html',
                controller: 'dataSetDetailsCtrl',
                controllerAs: 'vm'
            })
            .state('client.dataSetAll',
            {
                url: '/datasets',
                templateUrl: '/app/client/dataSet/all/dataSetAll.html',
                controller: 'dataSetAllCtrl',
                controllerAs: 'vm'
            })
            ;

        $urlRouterProvider.otherwise('/client/home');

        // This will make it look like the url is actually changing
        $locationProvider.hashPrefix('!');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false,
            rewriteLinks: true
        });

        OAuthProvider.configure({
            baseUrl: window.tryMLearningWebApiSrvUri,
            clientId: 'trymlearning-web',
            grantPath: '/Token',
            revokePath: '/api/Account/Logout'
        });

        OAuthTokenProvider.configure({
            options: {
                secure: false
            }
        });

        $httpProvider.interceptors.push("notAuthorizedInterceptor");
    }

    run.$inject = [
        '$rootScope',
        '$window',
        'OAuth',
        '$state'
    ];

    function run(
        $rootScope,
        $window,
        OAuth,
        $state
    ) {
        $rootScope.$on('oauth:error', function (event, rejection) {
            if ('invalid_grant' === rejection.data.error) {
                return;
            }

            if ('invalid_token' === rejection.data.error) {
                return OAuth.getRefreshToken();
            }

            $state.go('client.signin');
        });

        $rootScope.$on('auth:error', function (event, rejection) {
            $state.go('client.signin');
        });
    }
})();

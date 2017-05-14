(function () {
    'use strict';

    angular
        .module('app', [
            'ng',
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
            .state('client.home',
            {
                url: '/home',
                templateUrl: '/app/client/home/home.html',
                controller: 'homeCtrl',
                controllerAs: 'vm'
            })
            .state('client.algorithmAll',
            {
                url: '/algorithms',
                templateUrl: '/app/client/algorithm/all/algorithmAll.html',
                controller: 'algorithmAllCtrl',
                controllerAs: 'vm'
            })
            .state('client.datasetAll',
            {
                url: '/datasets',
                templateUrl: '/app/client/dataset/all/datasetAll.html',
                controller: 'datasetAllCtrl',
                controllerAs: 'vm'
            })
            ;

        $urlRouterProvider.otherwise('/client/home');

        //This will make it look like the url is actually changing
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
        });

        OAuthTokenProvider.configure({
            name: 'mytoken1',
            options: {
                secure: false
            },
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

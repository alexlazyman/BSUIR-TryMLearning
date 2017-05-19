(function () {
    'use strict';

    angular
        .module('app', [
            'ng',
            'angularSpinner',
            'ui.router',
            'angular-oauth2',
            'ui.bootstrap',
            'base64',
            'chart.js'
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
                controller: 'signinCtrl',
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
                abstract: true,
                url: '/algorithm',
                templateUrl: '/app/client/algorithm/algorithm.html'
            })
            .state('client.algorithm.details',
            {
                url: '?id',
                templateUrl: '/app/client/algorithm/details/algorithmDetails.html',
                controller: 'algorithmDetailsCtrl',
                controllerAs: 'vm'
            })
            .state('client.algorithm.all',
            {
                url: '/all',
                templateUrl: '/app/client/algorithm/all/algorithmAll.html',
                controller: 'algorithmAllCtrl',
                controllerAs: 'vm'
            })
            .state('client.dataSet',
            {
                abstract: true,
                url: '/dataset',
                templateUrl: '/app/client/dataSet/dataSet.html'
            })
            .state('client.dataSet.details',
            {
                url: '?id',
                templateUrl: '/app/client/dataSet/details/dataSetDetails.html',
                controller: 'dataSetDetailsCtrl',
                controllerAs: 'vm'
            })
            .state('client.dataSet.all',
            {
                url: '/all',
                templateUrl: '/app/client/dataSet/all/dataSetAll.html',
                controller: 'dataSetAllCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation',
            {
                abstract: true,
                url: '/estimation',
                templateUrl: '/app/client/estimation/estimation.html',
                controller: 'estimationCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation.add',
            {
                url: '/add',
                templateUrl: '/app/client/estimation/add/estimationAdd.html',
                controller: 'estimationAddCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation.all',
            {
                url: '/all',
                templateUrl: '/app/client/estimation/all/estimationAll.html',
                controller: 'estimationAllCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation.resultComposer',
            {
                url: '/result/composer?id&{e:json}',
                templateUrl: '/app/client/estimation/resultComposer/estimationResultComposer.html',
                controller: 'estimationResultComposerCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation.result',
            {
                url: '/result?id&{e:json}',
                params: {
                    e: null
                },
                templateUrl: '/app/client/estimation/result/estimationResult.html',
                controller: 'estimationResultCtrl',
                controllerAs: 'vm'
            })
            .state('client.estimation.compare',
            {
                url: '/compare?id&{e:json}',
                templateUrl: '/app/client/estimation/compare/estimationCompare.html',
                controller: 'estimationCompareCtrl',
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
            OAuth.revokeToken()
                .finally(function() {
                    $state.go('client.signin');
                });
        });
    }
})();

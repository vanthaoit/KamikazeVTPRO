/// <reference path="../../Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kamikazeVTPRO', ['kamikazeVTPRO.common','kamikazeVTPRO.config'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('base', {
            url: '',
            templateUrl: '/App/Backend/Shared/Views/templates.html',
            abstract: true
        }).state('login', {
            url: '/login',
            templateUrl: '/App/Backend/Components/Login/loginView.html',
            controller: 'LoginCtrl'
        }).state('home', {
            url: "/admin",
            parent: 'base',
            templateUrl: "/App/Backend/Components/Home/homeView.html",
            controller: "HomeCtrl"
        });
        $urlRouterProvider.otherwise('/login');
    }
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }

                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();
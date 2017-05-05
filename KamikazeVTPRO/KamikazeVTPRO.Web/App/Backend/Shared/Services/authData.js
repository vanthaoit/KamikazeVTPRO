/// <reference path="../../../../Assets/admin/libs/angular/angular.js" />
(function (app) {

    app.factory('authData', [function () {
        var authDataFactory = {};

        var authentication = {
            isAuthenticated: false,
            userName: ""
        };
        authDataFactory.credentials = authentication;

        return authDataFactory;
    }]);

})(angular.module('kamikazeVTPRO.common'));
/// <reference path="../../../../Assets/admin/libs/angular/angular.js" />
(function (app) {
    
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;
            var self = this;

            self.login = function (userName, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + userName + "&password=" + password;
                $http.post('/oauth/token', data, {
                    headers:
                    { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).then(function (response) {
                    userInfo = {
                        accessToken: response.data.access_token,
                        userName: userName
                    };
                    authenticationService.setTokenInfo(userInfo);
                    authData.credentials.isAuthenticated = true;
                    authData.credentials.userName = userName;
                    authData.credentials.accessToken = userInfo.accessToken;
                    deferred.resolve(null);
                }, function (err) {
                    authData.credentials.isAuthenticated = false;
                    authData.credentials.userName = "";
                    deferred.resolve(err);
                });
                    
                return deferred.promise;
            }

            self.logOut = function () {
                authenticationService.removeToken();
                authData.credentials.isAuthenticated = false;
                authData.credentials.userName = "";
            }
        }]);
})(angular.module("kamikazeVTPRO.common"));
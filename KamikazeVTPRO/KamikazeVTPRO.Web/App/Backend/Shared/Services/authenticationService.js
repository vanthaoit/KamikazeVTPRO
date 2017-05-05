(function (app) {
    
    app.service('authenticationService', ['$http', '$q', '$window', 'localStorageService','authData',
        function ($http, $q, $window, localStorageService, authData) {
            var tokenInfo;
            var self = this;

            self.setTokenInfo = function (data) {
                tokenInfo = JSON.stringify(data);
                localStorageService.set("TokenInfo", tokenInfo );
                
            }

            self.getTokenInfo = function () {
                return tokenInfo;
            }

            self.removeToken = function () {
                tokenInfo = null;
                localStorageService.remove("TokenInfo",null);
            }

            self.init = function () {
                var tokenInfo = localStorageService.get("TokenInfo");
                if (tokenInfo) {
                    tokenInfo = JSON.parse(tokenInfo);
                    authData.credentials.isAuthenticated = true;
                    authData.credentials.userName = tokenInfo.userName;
                    authData.credentials.accessToken = tokenInfo.accessToken;
                    
                }
            }

            self.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            self.validateRequest = function () {
                var url = 'api/home/MethodDefault';
                var deferred = $q.defer();
                $http.get(url).then(function () {
                    deferred.resolve(null);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            self.init();
        }
    ]);
})(angular.module('kamikazeVTPRO.common'));
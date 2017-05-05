(function (app) {

    app.controller('LoginCtrl', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {

                    
                    if (response != null) {
                        var grant_type_server = "grant_type=password&username=&password=";
                        if (grant_type_server.localeCompare(response.config.data) == 0)
                        {
                            notificationService.displayError("Tên đăng nhập hoặc mật khẩu không được phép rỗng !!!");
                        } else if (response.data.error != undefined) {
                            notificationService.displayError("Tên đăng nhập hoặc mật khẩu không đúng !!!");
                        }
                    } else
                    {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                  
                });
            }
        }]);

})(angular.module("kamikazeVTPRO"));
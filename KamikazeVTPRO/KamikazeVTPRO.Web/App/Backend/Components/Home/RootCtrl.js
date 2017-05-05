/// <reference path="../../../../Assets/admin/libs/angular/angular.js" />
(function (app) {
    
    app.controller('RootCtrl', ['$state', '$scope', 'authenticationService', 'authData', 'loginService',
        function ($state, $scope, authenticationService, authData, loginService) {
            
            $scope.logOut = function () {
                loginService.logOut();
                $state.go('login');
            }
            $scope.authentication = authData.authenticationData;


            $scope.sideBar = "/App/Backend/Shared/Views/sideBar.html";
        }
    ]);

    

})(angular.module("kamikazeVTPRO"));
(function (global, ng) {
    'use strict';
    function registrationController($scope, $http, $location, $cookies) {
        
        $scope.UserInfo = {
            UserEmail: '',
            UserPassword: '',
            ConfirmPassword: ''
        }

        $scope.register = function () {
            if ($scope.UserInfo.UserPassword === $scope.UserInfo.ConfirmPassword) {
                var data = {
                    'userEmail': $scope.UserInfo.UserEmail,
                    'userPassword': $scope.UserInfo.UserPassword
                };
                debugger;
                
                
                $http.post(
                    '/Registration/RegistrationOfNewUser', 
                    data
                    ).
                    success(function (data) {
                        $location.url('/login');
                    }).
                    error(function () {
                        $location.url('/409');
                    });
                
            }
        }
    }

    



    app.controller('registrationController', registrationController);
}(window, angular));

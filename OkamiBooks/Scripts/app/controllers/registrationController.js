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
                $http.post(
                    '/Registration/RegistrationOfNewUser', {
               Email: $scope.UserInfo.UserEmail,
               Password: $scope.UserInfo.UserPassword
                    }
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

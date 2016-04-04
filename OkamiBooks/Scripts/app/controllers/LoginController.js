(function (global, ng) {
    'use strict';
    function loginController($scope, $location, $http, $cookies) {
        $scope.UserInfo = {
            UserEmail: '',
            UserPassword: '',
            ConfirmPassword: ''
        }

        $scope.login = function () {
                $http.post(
                    '/Login/RegistrationOfNewUser', {
                        Email: $scope.UserInfo.UserEmail,
                        Password: $scope.UserInfo.UserPassword
                    }
                    ).
                    success(function (data) {
                        $cookies.put('userId', data[0]);
                        $cookies.put('accsessToken', data[1]);
                        $location.url('/main');
                    }).
                    error(function () {
                        $location.url('/409');
                    });
        }
    }
    app.controller('loginController', loginController);
}(window, angular));

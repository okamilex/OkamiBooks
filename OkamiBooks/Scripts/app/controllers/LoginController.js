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
                        if (data === "200") {
                            $cookies.put('userId', data[1]);
                            $cookies.put('accsessToken', data[2]);
                            $location.url('/main');
                        }
                    }).
                    error(function () {
                        $location.url('/409');
                    });
        }
    }
    app.controller('loginController', loginController);
}(window, angular));

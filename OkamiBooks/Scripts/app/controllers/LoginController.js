(function (global, ng) {
    'use strict';
    function loginController($scope, $location, $http, $cookies) {
        $scope.UserInfo = {
            UserEmail: '',
            UserPassword: ''
        }

        $scope.login = function () {
                $http.post(
                    '/Login/RegistrationOfNewUser', {
                        userEmail: $scope.UserInfo.UserEmail,
                        userPassword: $scope.UserInfo.UserPassword
                    }
                    ).
                    success(function (data) {
                        if (data.code === '200') {
                            $cookies.put('userName', data.userName);
                            $cookies.put('accsessToken', data.accsessToken);
                            $location.url('/main');
                        }
                        if (data[0] === '200') {
                            $cookies.put('userName', data[1]);
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

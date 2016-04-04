(function (global, ng) {
    'use strict';
    function userController($scope, $http, $cookies ,$location) {
        $http.post(
                     '/User/GetUser', {
                         userName: $cookies.getObject('userName'),
                         accsessToken: $cookies.getObject('accsessToken')
                     }
                     ).
                     success(function (data) {
                         if (data === "200") {
                             $cookies.put('userName', data[1]);
                             $cookies.put('accsessToken', data[2]);
                             $location.url('/main');
                         }
                     }).
                     error(function () {
                         $location.url('/409');
                     });
    }
    app.controller('userController', userController);
}(window, angular));

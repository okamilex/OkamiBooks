(function (global, ng) {
    'use strict';
    function userController($scope, $http, $cookies ,$location) {
        $http({
            method: "POST",
            //data: $cookies.userId,
            url: "User/GetUser"
        }).then(function mySucces(response) {
            $scope.people = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
    }
    app.controller('userController', userController);
}(window, angular));

(function(global, ng) {
    'use strict';
  
    function peopleController($scope, $http, $location,  $cookies) {
        $http({
            method: "GET",
            url: "People/GetUsers"
        }).then(function mySucces(response) {
            $scope.people = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });

        }
    app.controller('peopleController', peopleController);
}(window, angular));
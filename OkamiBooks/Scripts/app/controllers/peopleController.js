(function(global, ng) {
    'use strict';
  
    function peopleController($scope, $http, $location,  $cookies) {
        $http({
            method: "GET",
            url: "People/GetUsers"
        }).then(function mySucces(response) {
            $scope.people = response.data;
        }, function myError(response) {
            
        });
        var people = $scope.people;
        people = people;
        if ($cookies.get('userId') == null) {
            var postData = [-1, -1];
            $http({
                method: "POST",
                data: postData,
                url: "Home/GetUser"
            }).then(function mySucces(response) {
                $cookies.put('userId', response.data[0]);
                $cookies.put('accsessToken', response.data[1]);
            }, function myError(response) {
                $location.url('/409');
            });
        }
        }
    app.controller('peopleController', peopleController);
}(window, angular));
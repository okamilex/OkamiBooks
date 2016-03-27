'use strict';


var peopleController = function ($scope, $http) {
   // var futureResponse = $http.get('Home/GetAllUsers')

    $http({
        method: "GET",
        url: "Home/GetAllUsers"
    }).then(function mySucces(response) {
        $scope.people = response.data;
    }, function myError(response) {
        $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
    });

    //.then(function (response) {
  //      var people = response.data;
    //    $scope.people = people;
   // });
    //var people = [{ id: 10 }, { id: 11 }, {id: 41}];
    //var futureResponse = $http.get('users.json');
    //futureResponse.success(function(data, status, headers, config) {
           // people = data;
    //});
 

};
    mainApp.controller('peopleController', peopleController);

'use strict';


var homeController = function ($scope, $http) {

    debugger;
    $scope.latestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];
    $scope.bestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];


};
mainApp.controller('homeController', homeController);

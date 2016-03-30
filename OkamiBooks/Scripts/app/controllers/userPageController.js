'use strict';


var userPageController = function ($scope, $routeParams, $http) {

    $scope.UserId = $routeParams.UserId;
    $scope.people = [{ Id: 2, Login: "gutd", Reiting: 5, BA: 2, Books: [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }] }, { Id: 5, Login: "gufgjtd", Reiting: 4, BA: 2, Books: [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }] }, { Login: "gutdd", Reiting: 5, BA: 2, Books: [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }] }]

    $scope.user = { Id: 2, Login: "gutd", Reiting: 5, BA: 2, Books: [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }] }, { Id: 5, Login: "gufgjtd", Reiting: 4, BA: 2, Books: [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }] };


};
mainApp.controller('userPageController', userPageController);
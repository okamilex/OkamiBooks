(function (global, ng) {
    'use strict';
    function userPageController($scope, $location) {
        $scope.latestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];
        $scope.bestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];
    }
    app.controller('userPageController', userPageController);
}(window, angular));
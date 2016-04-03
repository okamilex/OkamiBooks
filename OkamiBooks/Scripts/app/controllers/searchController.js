(function (global, ng) {
    'use strict';
    function searchController($scope, $location) {
        $scope.findBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];
      
    }
    app.controller('searchController', searchController);
}(window, angular));

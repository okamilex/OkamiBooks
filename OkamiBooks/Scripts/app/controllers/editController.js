(function (global, ng) {
    'use strict';
    function editController($scope, $location) {
        $http({
            method: "GET",
            url: "Home/GetCategories"
        }).then(function mySucces(response) {
            $scope.categories = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });

          $scope.tags = [{ Name: "hds" }, { Name: "etu" }, { Name: "jggds" }, { Name: "hdsgs" }];

    }

    



    app.controller('editController', editController);
}(window, angular));

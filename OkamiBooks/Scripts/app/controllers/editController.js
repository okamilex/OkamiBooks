(function (global, ng) {
    'use strict';
    function editController($scope, $location) {
        $scope.categories = [{ Name: "Sci-fi" }, { Name: "Fantazy" }, { Name: "Kids" }, { Name: "Adolts" }];
        $scope.tags = [{ Name: "hds" }, { Name: "etu" }, { Name: "jggds" }, { Name: "hdsgs" }];

    }

    



    app.controller('editController', editController);
}(window, angular));

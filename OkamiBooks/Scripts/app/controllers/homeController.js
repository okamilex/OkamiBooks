(function (global, ng) {
    'use strict';
    function homeController($scope, $location) {
        $scope.latestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];
        $scope.bestBooks = [{ Id: 1, Name: "First Book" }, { Id: 2, Name: "Second Book" }];

        var wordList = ['aaaaa', 'bBbb', 'CCC', 'dd'];

        $scope.words = [{text: "", size: 1}];

        for (var i = 0; i < 4; i += 1) {
            $scope.words.push({
                text: wordList[i],
                size: Math.floor((Math.random() * 5) + i)
            });
        }
    }
    app.controller('homeController', homeController);
}(window, angular));

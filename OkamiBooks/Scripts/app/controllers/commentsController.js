(function (global, ng) {
    'use strict';
    function commentsController($scope, $location) {
        $scope.comments = [{ UserName: "saf", CommentText: "asgagshgas gasgsafg ag a ags gas", LikeAmount: 5 }, { UserName: "satf", CommentText: "asgasdgf gsds hgas gad sgsafg ag a ags gas", LikeAmount: 6 }]
      
    }
    app.controller('commentsController', commentsController);
}(window, angular));
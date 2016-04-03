(function(global, ng) {
    'use strict';
  
    function peopleController($scope, $location,  $cookies) {
        

        $scope.people = [{ Id: 2, Login: "gutd", Reiting: 5, BA: 2 }, { Id: 5, Login: "gufgjtd", Reiting: 4, BA: 2 }, { Id: 7, Login: "gutdd", Reiting: 5, BA: 2 }];
    }
    app.controller('peopleController', peopleController);
}(window, angular));
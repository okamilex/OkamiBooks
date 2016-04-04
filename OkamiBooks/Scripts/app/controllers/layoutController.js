(function (global, ng) {
    'use strict';
    function layoutController($scope, $http, $cookies, $location) {
        
        if (($cookies.get('lang') == undefined)) {
            {
                $cookies.put('lang', 'en');
            }
        };
        
        if (($cookies.get('theme') == undefined)) {
            {
                $cookies.put('theme', 'l');
            }
        };
        $scope.theme = $cookies.get('theme');
        $scope.changeTheme = function () {
            if (($cookies.get('theme') === 'b')) {
                
                    $cookies.put('theme', 'l');
                
            } else {
                $cookies.put('theme', 'b');
            }

        };


    }
    app.controller('layoutController', layoutController);
}(window, angular));

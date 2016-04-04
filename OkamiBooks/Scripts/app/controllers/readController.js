(function (global, ng) {
    'use strict';
    function readController($scope, $location, $http, $cookies) {

        if ($cookies.get('userId') == null) {
            var postData = [-1, -1];
            $http({
                method: "POST",
                data: postData,
                url: "Home/GetUser"
            }).then(function mySucces(response) {
                $cookies.put('userId', response.data[0]);
                $cookies.put('accsessToken', response.data[1]);
            }, function myError(response) {
                $location.url('/409');
            });
        }
        
    }
    app.controller('readController', readController);
}(window, angular));

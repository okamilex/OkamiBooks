(function(global, ng) {
    'use strict';
  
    function peopleController($scope, $http, $location, $cookies) {
        var people;
        $http({
            method: "GET",
            url: "People/GetUsers"
        }).then(function mySucces(response) {
            $scope.people = response.data;
        }, function myError(response) {
            
        });
        people = $scope.people;
        $scope.setUser = function(user) {
            var data = {
                'selectedId': user,
                'userName': $cookies.get('userName')
            };
            $http.post(
                    '/People/PostForUser',
                    data
                ).
                success(function(data) {
                    $location.url('/user');
                }).
                error(function() {
                    $location.url('/409');
                });

        };

        var userName = $cookies.get('userName');
        if (userName === undefined) {
            $http.post(
                'Home/UserGetting', {
                    'userName': -1,
                    'accsessToken': -1
                }
            ).
            success(function (data) {
                $cookies.put('userName', data[0]);
                $cookies.put('accsessToken', data[1]);
            }).
            error(function () {
                deferredObject.resolve({ success: false });
            });
        }
        if (($cookies.get('lang') === undefined)) {
            {
                $cookies.put('lang', 'en');
            }
        };
        if (($cookies.get('theme') === undefined)) {
            {
                $cookies.put('theme', 'l');
            }
        };
        }
    app.controller('peopleController', peopleController);
}(window, angular));
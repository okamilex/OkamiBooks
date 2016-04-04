(function (global, ng) {
    'use strict';
    function userController($scope, $http, $cookies, $location) {
        
        var myData = {
            'userName': $cookies.get('userName')
        };
        
        $http.post('/User/GetBooks', myData).
                     success(function (data) {
                         $scope.books = angular.fromJson(data);
                     }).
                     error(function () {
                         $location.url('/409');
                     });
        $http.post('/User/GetUser', myData).
                     success(function (data) {
                         $scope.user = angular.fromJson(data);
                     }).
                     error(function () {
                         $location.url('/409');
                     });
        
        myData = {
            'userName': $cookies.get('userName'),
            'accsessToken': $cookies.get('accsessToken')
        };
        $http.post('/User/GetProm', myData).
                     success(function (data) {
                         var newData = angular.fromJson(data);
                         
                             $cookies.put('userName', newData.userName);
                             $cookies.put('accsessToken', newData.accsessToken);
                             $scope.permission = newData.prom;
                         
                         
            }).
                     error(function () {
                         $location.url('/409');
                     });

        if ($cookies.get('userName') === undefined) {
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

        $scope.startEditNewBook = function () {
            var data = {
                
                'userName': $cookies.get('userName'),
                'accsessToken': $cookies.get('accsessToken')
            };
            $http.post(
                    '/User/NewBook',
                    data
                ).
                success(function (data) {
                    $location.url('/edit');
                }).
                error(function () {
                    $location.url('/409');
                });
            
        }


        
    }
    app.controller('userController', userController);
}(window, angular));

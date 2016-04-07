(function (global, ng) {
    'use strict';
    function readController($scope, $location, $http, $cookies) {

        if (($cookies.get('col') == undefined)) {
            {
                $cookies.put('col', '12');
            }
        };
       
        $scope.col = $cookies.get('col');
        $scope.changeCol = function () {
            if (($cookies.get('col') === '12')) {
                $cookies.put('col', '9');
            } else {
                if (($cookies.get('col') === '9')) {
                    $cookies.put('col', '6');
                } else {
                    $cookies.put('col', '12');
                }
            }
            $scope.col = $cookies.get('col');
        };
        if (($cookies.get('rows') == undefined)) {
            {
                $cookies.put('rows', '6');
            }
        };
        $scope.rows = $cookies.get('rows');
        $scope.changeRows = function () {
            if (($cookies.get('rows') === '6')) {
                $cookies.put('rows', '3');
            } else {
                if (($cookies.get('rows') === '3')) {
                    $cookies.put('rows', '1');
                } else {
                    $cookies.put('rows', '6');
                }
            }
            $scope.rows = $cookies.get('rows');
        };


        var myData = {
            'userName': $cookies.get('userName'),
            'accsessToken': $cookies.get('accsessToken')
        };
        $http.post('/Read/ChaekPrev', myData).
            success(function (data) {
                $scope.prev = data;
            }).
            error(function () {
                $location.url('/409');
            });
        $http.post('/Read/ChaekNext', myData).
            success(function (data) {
                $scope.next = data;
            }).
            error(function () {
                $location.url('/409');
            });
        $http.post('/Read/GetText', myData).
            success(function(data) {
                $scope.text = data;
            }).
            error(function() {
                $location.url('/409');
            });
        $scope.getPrev = function() {
            $http.post('/Read/GetPrev', myData).
                success(function (data) {
                    var newDat = angular.fromJson(data);
                    $scope.text = newDat.text;
                    $scope.prev = newDat.prev;
                    $scope.next = newDat.next;
                }).
                error(function() {
                    $location.url('/409');
                });
            
            
        }
        $scope.getNext = function () {
            $http.post('/Read/GetNext', myData).
                success(function (data) {
                    var newDat = angular.fromJson(data);
                    $scope.text = newDat.text;
                    $scope.prev = newDat.prev;
                    $scope.next = newDat.next;
                }).
                error(function () {
                    $location.url('/409');
                });
            
            
        }


    }
    app.controller('readController', readController);
}(window, angular));

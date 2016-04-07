(function (global, ng) {
    'use strict';
    function commentsController($scope, $http, $cookies, $location) {
         var myData = {
            'userName': $cookies.get('userName'),
            'accsessToken': $cookies.get('accsessToken')
        };
        $http.post('/Comments/Get', myData).
            success(function (data) {
                var newData = angular.fromJson(data);
                $scope.comments = newData.comments;
                $scope.rating = newData.rating;
                $scope.myRating = newData.myRating;
                $scope.isUser = newData.isUser;
                $scope.isRated = newData.isRated;
            }).
            error(function () {
                $location.url('/409');
            });
        $scope.add = function() {
            $http.post('/Comments/Add', myData).
                success(function(data) {
                    var newData = angular.fromJson(data);
                    $scope.comments = newData.comments;
                }).
                error(function() {
                    $location.url('/409');
                });
        }
        $scope.rate = function (mark) {
            var myDataRate = {
                'userName': $cookies.get('userName'),
                'accsessToken': $cookies.get('accsessToken'),
                'mark': mark
            };
                $http.post('/Comments/Rate', myDataRate).
                    success(function(data) {
                        var newData = angular.fromJson(data);
                        $scope.rating = newData.rating;
                        $scope.myRating = newData.myRating;
                    }).
                    error(function() {
                        $location.url('/409');
                    });
            }
        }
    app.controller('commentsController', commentsController);
}(window, angular));
(function (global, ng) {
    'use strict';
    function homeController($scope, $http, $cookies, $location) {
        $http({
            method: "GET",
            url: "Home/GetBestBooks"
        }).then(function mySucces(response) {
            $scope.bestBooks = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
        $http({
            method: "GET",
            url: "Home/GetLastBooks"
        }).then(function mySucces(response) {
            $scope.latestBooks = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
        $http({
            method: "GET",
            url: "Home/GetCategories"
        }).then(function mySucces(response) {
            $scope.categories = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
        $http({
            method: "GET",
            url: "Home/GetTags"
        }).then(function mySucces(response) {
            $scope.words = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
        
        if ($cookies.getObject('userName') == undefined)  {
            $http.post(
                'Home/UserGetting', {
                    userName: -1,
                    accsessToken: -1
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
        if (($cookies.getObject('lang') == undefined)) {
            {
                $cookies.put('lang', 'en');
            }
        };
        if (($cookies.getObject('theme') == undefined)) {
            {
                $cookies.put('theme', 'l');
            }
        };

    }
    app.controller('homeController', homeController);
}(window, angular));

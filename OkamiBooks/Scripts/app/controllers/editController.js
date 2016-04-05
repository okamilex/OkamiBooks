(function (global, ng) {
    'use strict';

    function editController($scope, $http, $cookies, $location) {
        $http({
            method: "GET",
            url: "Home/GetCategories"
        }).then(function mySucces(response) {
            $scope.categories = response.data;
        }, function myError(response) {
            $scope.myWelcome = [{ id: 10 }, { id: 11 }, { id: 41 }];
        });
        var myData = {
            'userName': $cookies.get('userName'),
            'accsessToken': $cookies.get('accsessToken')
        };
        $http.post('/Edit/GetChap', myData).
            success(function (data) {

                $scope.chapters = data;


            }).
            error(function () {
                $location.url('/409');
            });
        $http.post('/Edit/GetName', myData).
            success(function (data) {

                $scope.name = data;

                
            }).
            error(function () {
                $location.url('/409');
            });
        $http.post('/Edit/GetCategory', myData).
            success(function (data) {

                $scope.bookCategory = data;


            }).
            error(function () {
                $location.url('/409');
            });
        $scope.newChapterMy = '';
        $scope.text = '';
        $scope.chapterNum = '';
        $scope.addChapter = function () {
            if ($scope.newChapterMy !== '') {
                $http.post(
                        '/Edit/AddChapter', {
                            userName: $cookies.get('userName'),
                            accsessToken: $cookies.get('accsessToken'),
                            chapterName: $scope.newChapterMy,
                            text: $scope.text
                        }
                    ).
                    success(function (data) {
                        $scope.chapters = data;
                        $scope.newChapterMy = '';

                    }).
                    error(function () {
                        $location.url('/409');
                    });
            }
        }
        $scope.postName = function () {

            $http.post(
                    '/Edit/PostName', {
                        userName: $cookies.get('userName'),
                        accsessToken: $cookies.get('accsessToken'),
                        bookName: $scope.name
                    }
                ).
                success(function (data) {


                }).
                error(function () {

                });

        }
        $scope.postCategory = function () {

            $http.post(
                    '/Edit/PostCategory', {
                        userName: $cookies.get('userName'),
                        accsessToken: $cookies.get('accsessToken'),
                        bookCategory: $scope.bookCategory
                    }
                ).
                success(function (data) {


                }).
                error(function () {

                });

        }
        $scope.setChapter = function (chapter) {
            $scope.chapterNum = chapter;
            $http.post(
                        '/Edit/GetText', {
                            userName: $cookies.get('userName'),
                            accsessToken: $cookies.get('accsessToken'),
                            chapterId: $scope.chapterNum
                        }
                    ).
                    success(function (data) {
                    $scope.text = data;
                }).
                    error(function () {
                        $location.url('/409');
                    });
        }
        $scope.postText = function () {
            if ($scope.chapterNum !== '') {
                $http.post(
                        '/Edit/PostText', {
                            userName: $cookies.get('userName'),
                            accsessToken: $cookies.get('accsessToken'),
                            chapterId: $scope.chapterNum,
                            text: $scope.text
                        }
                    ).
                    success(function (data) {
                    }).
                    error(function () {
                        $location.url('/409');
                    });
            }
        }
    }

    app.controller('editController', editController);
}(window, angular));
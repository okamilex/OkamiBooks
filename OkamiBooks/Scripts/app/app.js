(function (global, ng) {

    'use strict';



    global.app = angular.module('app', [
       'ngRoute', 'ngResource', 'ngCookies'
    ]);

    app.config([
            '$routeProvider',
            '$locationProvider',
            function ($routeProvider, $locationProvider) {

                // $locationProvider.html5Mode(true);

                $routeProvider.
                 when('/main', {
                     templateUrl: "/home/home",
                     controller: 'homeController'
                 }).
                 when('/people', {
                     templateUrl: "/people",
                     controller: 'peopleController'
                 }).
                 when('/user', {
                     templateUrl: "/user",
                     controller: 'userController'
                 }).
                 when('/read', {
                     templateUrl: "/read",
                     controller: 'readController'
                 }).
                 when('/edit', {
                     templateUrl: "/edit",
                     controller: 'editController'
                 }).
                 when('/comments', {
                     templateUrl: "/comments",
                     controller: 'commentsController'
                 }).
                 when('/search', {
                     templateUrl: "/search",
                     controller: 'searchController'
                 }).
                 when('/login', {
                        templateUrl: "/login",
                        controller: 'searchController'
                    }).
                    when('/registration', {
                        templateUrl: "/registration",
                        controller: 'registrationController'
                    }).
                 otherwise({
                     redirectTo: '/main'
                 });
            }
    ])
    .run([
        '$rootScope', '$location',
        function ($rootScope, $location) {

        }
    ]);
}(this, angular));
